/*
 * Copyright 2004-2014 the Seasar Foundation and the Others.
 *
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 *     http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND,
 * either express or implied. See the License for the specific language
 * governing permissions and limitations under the License.
 */
package org.seasar.dbflute.net.migration.tools;

import java.io.File;
import java.io.IOException;
import java.io.UnsupportedEncodingException;
import java.util.ArrayList;
import java.util.List;
import java.util.Map;
import java.util.Map.Entry;
import java.util.TreeMap;

import org.dbflute.utflute.core.filesystem.FileLineHandler;
import org.dbflute.utflute.core.policestory.javaclass.PoliceStoryJavaClassHandler;
import org.dbflute.utflute.core.policestory.miscfile.PoliceStoryMiscFileHandler;
import org.dbflute.util.Srl;
import org.seasar.dbflute.net.migration.tools.handler.MigrationFileLineHandler;
import org.seasar.dbflute.net.migration.unit.UnitContainerTestCase;
import org.seasar.framework.util.FileUtil;

/**
 * @author jflute
 */
public class ToolsMigrationResearchTest extends UnitContainerTestCase {

    // ===================================================================================
    //                                                                          Definition
    //                                                                          ==========
    protected static final String TEXT_ENCODING = "UTF-8"; // all files are same
    protected static final String EXTENSION_PREFIX = "Extension";
    protected static final int REFERRER_LIMIT = 120;

    // -----------------------------------------------------
    //                                            Source Map
    //                                            ----------
    protected static final String KEY_SIMPLE_NAME = "simpleName"; // key (but SqlDate if java.sql.Date)
    protected static final String KEY_SOURCE_FILE_PATH = "sourceFilePath";
    protected static final String KEY_PENDING_LIST = "pendingList";

    // -----------------------------------------------------
    //                                        Import API Map
    //                                        --------------
    protected static final String KEY_IMPORT_CLASS_NAME = "importClassName"; // key
    protected static final String KEY_IMPORT_SIMPLE_NAME = "importSimpleName";
    protected static final String KEY_REFERRER_LIST = "referrerList";
    protected static final String KEY_MIGRATION_TARGET = "migrationTarget";

    // ===================================================================================
    //                                                                            Settings
    //                                                                            ========
    @Override
    protected boolean isUseRuntimeDirectPoliceStory() {
        return true;
    }

    // ===================================================================================
    //                                                                            Research
    //                                                                            ========
    public void test_research() throws Exception {
        final Map<String, Map<String, Object>> sourceMap = prepareSourceMap();
        final Map<String, Map<String, Object>> importApiMap = prepareImportApiMap();
        mergeJavaLang(sourceMap, importApiMap);

        final int maxClassNameLength = calculateMaxClassnameLength(importApiMap);
        final StringBuilder sb = new StringBuilder();
        sb.append("This file is auto-generated so you cannot modify this directly.");
        sb.append(ln()).append("(research at ").append(toString(currentDate(), "yyyy/MM/dd HH:mm:ss")).append(")");
        sb.append(ln()).append(ln());

        for (Entry<String, Map<String, Object>> entry : importApiMap.entrySet()) {
            final Map<String, Object> elementMap = entry.getValue();
            final String importClassName = (String) elementMap.get(KEY_IMPORT_CLASS_NAME);
            final String importSimpleName = (String) elementMap.get(KEY_IMPORT_SIMPLE_NAME);
            @SuppressWarnings("unchecked")
            final List<Class<?>> referrerList = (List<Class<?>>) elementMap.get(KEY_REFERRER_LIST);
            final boolean migrationTarget = (Boolean) elementMap.get(KEY_MIGRATION_TARGET);

            final String sourceKey = generateSourceKey(importClassName, importSimpleName);
            Map<String, Object> sourecElementMap = sourceMap.get(sourceKey);
            boolean existsPending = false;
            if (sourecElementMap == null) {
                sourecElementMap = sourceMap.get(sourceKey + EXTENSION_PREFIX); // retry as extension
                if (sourecElementMap == null) {
                    if (importApiMap.containsKey(Srl.substringLastFront(importClassName, "."))) {
                        continue; // e.g. Map.Entry
                    }
                }
            } else {
                @SuppressWarnings("unchecked")
                final List<String> pendingList = ((List<String>) sourecElementMap.get(KEY_PENDING_LIST));
                existsPending = !pendingList.isEmpty();
            }
            final String mark = migrationTarget ? (sourecElementMap != null ? (existsPending ? "v" : "o") : "x") : "n";

            sb.append("[").append(mark).append("] ").append(importClassName);
            if (!referrerList.isEmpty()) {
                buildReferrerInfo(sb, referrerList, importClassName, maxClassNameLength);
            }
            if (sourecElementMap != null) {
                buildSourceInfo(sb, sourecElementMap);
            }
            sb.append(ln());
        }
        final String text = sb.toString();
        log(ln() + text);
        outputReportFile(text);
        refreshMigrationProject();
    }

    // ===================================================================================
    //                                                                             Analyze
    //                                                                             =======
    protected Map<String, Map<String, Object>> prepareSourceMap() throws IOException {
        final Map<String, Map<String, Object>> sourceMap = newLinkedHashMap();
        policeStoryOfMiscFileChase(new PoliceStoryMiscFileHandler() {
            public void handle(File miscFile) {
                final String name = miscFile.getName();
                if (!name.endsWith(".cs")) {
                    return;
                }
                try {
                    final String canonicalPath = miscFile.getCanonicalPath();
                    if (!canonicalPath.contains("/JavaLike/")) {
                        return;
                    }
                    final String simpleName = Srl.substringLastFront(name, ".cs");
                    final String sourceFilePath = Srl.substringLastRear(canonicalPath, "/DBFluteRuntime/");

                    final Map<String, Object> elementMap = newLinkedHashMap();
                    elementMap.put(KEY_SIMPLE_NAME, simpleName);
                    elementMap.put(KEY_SOURCE_FILE_PATH, sourceFilePath);
                    elementMap.put(KEY_PENDING_LIST, new ArrayList<String>());
                    final String sourceKey = generateSourceKey(sourceFilePath, simpleName);
                    sourceMap.put(sourceKey, elementMap);

                    readLine(miscFile, TEXT_ENCODING, new FileLineHandler() {
                        public void handle(String line) {
                            if (line.contains("#pending")) {
                                @SuppressWarnings("unchecked")
                                List<String> pendingList = (List<String>) elementMap.get(KEY_PENDING_LIST);
                                if (pendingList == null) {
                                    pendingList = newArrayList();
                                    elementMap.put(KEY_PENDING_LIST, pendingList);
                                }
                                pendingList.add(line.trim());
                            }
                        }
                    });
                } catch (IOException e) {
                    throw new IllegalStateException(e);
                }
            }
        }, getNetRuntimeSourceDir());
        return sourceMap;
    }

    protected Map<String, Map<String, Object>> prepareImportApiMap() {
        final Map<String, Map<String, Object>> importApiMap = new TreeMap<String, Map<String, Object>>();
        policeStoryOfJavaClassChase(new PoliceStoryJavaClassHandler() {
            public void handle(File srcFile, Class<?> clazz) {
                final MigrationFileLineHandler handler = new MigrationFileLineHandler();
                readLine(srcFile, TEXT_ENCODING, handler);
                final List<String> importList = handler.toJavaInfo().getImportList();
                for (String importClassName : importList) {
                    if (importClassName.startsWith("java")) {
                        Map<String, Object> elementMap = importApiMap.get(importClassName);
                        if (elementMap == null) {
                            elementMap = newLinkedHashMap();
                            elementMap.put(KEY_IMPORT_CLASS_NAME, importClassName);
                            elementMap.put(KEY_IMPORT_SIMPLE_NAME, Srl.substringLastRear(importClassName, "."));
                            elementMap.put(KEY_REFERRER_LIST, new ArrayList<Class<?>>());
                            elementMap.put(KEY_MIGRATION_TARGET, false); // as default
                            importApiMap.put(importClassName, elementMap);
                        }
                        @SuppressWarnings("unchecked")
                        final List<Class<?>> referrerList = (List<Class<?>>) elementMap.get(KEY_REFERRER_LIST);
                        referrerList.add(clazz);
                        if (!isOutOfMigrationClass(clazz)) {
                            elementMap.put(KEY_MIGRATION_TARGET, true);
                        }
                    }
                }
            }
        });
        return importApiMap;
    }

    protected void mergeJavaLang(final Map<String, Map<String, Object>> sourceMap,
            final Map<String, Map<String, Object>> importApiMap) {
        for (Entry<String, Map<String, Object>> entry : sourceMap.entrySet()) {
            final Map<String, Object> elementMap = entry.getValue();
            final String sourceFilePath = (String) elementMap.get(KEY_SOURCE_FILE_PATH);
            final String simpleName = (String) elementMap.get(KEY_SIMPLE_NAME);
            if (sourceFilePath.startsWith("JavaLike/Lang")) {
                final String importSimpleName;
                if (simpleName.endsWith(EXTENSION_PREFIX)) {
                    importSimpleName = Srl.substringLastFront(simpleName, EXTENSION_PREFIX);
                } else {
                    importSimpleName = simpleName;
                }
                final String importClassName = "java.lang." + importSimpleName;
                final Map<String, Object> valueMap = newLinkedHashMap();
                valueMap.put(KEY_IMPORT_CLASS_NAME, importClassName);
                valueMap.put(KEY_IMPORT_SIMPLE_NAME, simpleName);
                valueMap.put(KEY_REFERRER_LIST, new ArrayList<String>());
                valueMap.put(KEY_MIGRATION_TARGET, true);
                importApiMap.put(importClassName, valueMap);
            }
        }
    }

    // ===================================================================================
    //                                                                              Output
    //                                                                              ======
    protected void buildReferrerInfo(StringBuilder sb, List<Class<?>> referrerList, String importClassName,
            int maxClassNameLength) {
        sb.append(calculateClassRearSpace(maxClassNameLength, importClassName));
        final int referrerSize = referrerList.size();
        sb.append(" {").append(Srl.lfill(String.valueOf(referrerSize), 3)).append(": ");
        StringBuilder referrerSb = new StringBuilder();
        final List<Class<?>> outOfReferrerList = newArrayList();
        boolean overLimit = false;
        for (Class<?> referrer : referrerList) {
            if (isOutOfMigrationClass(referrer)) {
                outOfReferrerList.add(referrer);
                continue; // priority low
            }
            if (referrerSb.length() > 0) {
                referrerSb.append(", ");
            }
            referrerSb.append(referrer.getSimpleName());
            if (referrerSb.length() > REFERRER_LIMIT) {
                referrerSb.append(", ...");
                overLimit = true;
                break;
            }
        }
        if (!overLimit) {
            for (Class<?> referrer : outOfReferrerList) {
                if (referrerSb.length() > 0) {
                    referrerSb.append(", ");
                }
                referrerSb.append(referrer.getSimpleName()).append("(n)");
                if (referrerSb.length() > REFERRER_LIMIT) {
                    referrerSb.append(", ...");
                    overLimit = true;
                    break;
                }
            }
        }
        sb.append(referrerSb).append("}");
    }

    protected void buildSourceInfo(final StringBuilder sb, Map<String, Object> sourecElementMap) {
        final String sourceFilePath = (String) sourecElementMap.get(KEY_SOURCE_FILE_PATH);
        @SuppressWarnings("unchecked")
        final List<String> pendingList = (List<String>) sourecElementMap.get(KEY_PENDING_LIST);
        sb.append(ln()).append("   -> ").append(sourceFilePath);
        for (String pending : pendingList) {
            sb.append(ln()).append("      ").append(pending);
        }
        sb.append(ln());
    }

    protected String generateSourceKey(String className, String simpleName) {
        return simpleName.equals("Date") && Srl.containsIgnoreCase(className, "sql") ? "SqlDate" : simpleName;
    }

    protected int calculateMaxClassnameLength(Map<String, Map<String, Object>> importApiMap) {
        int maxClassNameLength = 0;
        for (Entry<String, Map<String, Object>> entry : importApiMap.entrySet()) {
            final Map<String, Object> elementMap = entry.getValue();
            final String importClassName = (String) elementMap.get(KEY_IMPORT_CLASS_NAME);
            maxClassNameLength = Math.max(maxClassNameLength, importClassName.length());
        }
        return maxClassNameLength;
    }

    protected String calculateClassRearSpace(final int maxClassNameLength, final String importClassName) {
        final int addedSpaceLength = maxClassNameLength - importClassName.length();
        final StringBuilder spaceSb = new StringBuilder();
        for (int i = 0; i < addedSpaceLength; i++) {
            spaceSb.append(" ");
        }
        final String adjustedSpace = spaceSb.toString();
        return adjustedSpace;
    }

    protected void outputReportFile(final String text) throws IOException, UnsupportedEncodingException {
        FileUtil.write(getProjectDir().getCanonicalPath() + "/research_report.txt", text.getBytes(TEXT_ENCODING));
    }
}
