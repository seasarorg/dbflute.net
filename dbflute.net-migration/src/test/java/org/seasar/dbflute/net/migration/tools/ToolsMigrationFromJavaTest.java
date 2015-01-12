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
import java.util.List;

import org.dbflute.helper.filesystem.FileTextIO;
import org.dbflute.utflute.core.policestory.javaclass.PoliceStoryJavaClassHandler;
import org.dbflute.util.Srl;
import org.seasar.dbflute.net.migration.tools.handler.MigrationFileLineHandler;
import org.seasar.dbflute.net.migration.unit.UnitContainerTestCase;

/**
 * @author jflute
 */
public class ToolsMigrationFromJavaTest extends UnitContainerTestCase {

    @Override
    protected boolean isUseRuntimeDirectPoliceStory() {
        return true;
    }

    public void test_making() throws Exception {
        policeStoryOfJavaClassChase(new PoliceStoryJavaClassHandler() {
            public void handle(File srcFile, Class<?> clazz) {
                if (clazz.getName().contains("org.dbflute.system")) {
                    migrateToCSharp(srcFile, clazz);
                }
            }
        });
        refreshMigrationProject();
    }

    protected void migrateToCSharp(File srcFile, Class<?> clazz) {
        MigrationFileLineHandler handler = new MigrationFileLineHandler();
        readLine(srcFile, "UTF-8", handler);
        try {
            String textPath = buildOutputTextPath(clazz);
            mkdirsIfNeeds(textPath);
            String text = handler.toCSharpString();
            log(ln() + text);
            new FileTextIO().encodeAsUTF8().write(textPath, text);
        } catch (IOException e) {
            throw new IllegalStateException(e);
        }
    }

    protected String buildOutputTextPath(Class<?> clazz) throws IOException {
        File sourceDir = getNetRuntimeSourceDir();
        String canonicalPath = sourceDir.getCanonicalPath();
        String className = clazz.getName();
        List<String> splitList = Srl.splitList(className, ".");
        StringBuilder sb = new StringBuilder();
        for (String element : splitList) {
            if (sb.length() > 0) {
                sb.append("/");
            } else if ("org".equals(element) || "dbflute".equals(element)) {
                continue;
            }
            element = element.equals("system") ? "DfSystem" : element;
            sb.append(Srl.initCap(element));
        }
        return canonicalPath + "/DBFlute/" + sb.toString() + ".cs";
    }

    protected void mkdirsIfNeeds(String textPath) {
        File baseDir = new File(Srl.substringLastFront(textPath, "/"));
        if (!baseDir.exists()) {
            baseDir.mkdirs();
        }
    }
}
