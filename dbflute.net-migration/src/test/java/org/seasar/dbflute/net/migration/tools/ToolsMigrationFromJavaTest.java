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
import java.util.List;

import org.seasar.dbflute.net.migration.MigrationExample;
import org.seasar.dbflute.net.migration.unit.UnitContainerTestCase;
import org.seasar.dbflute.unit.core.filesystem.FileLineHandler;
import org.seasar.dbflute.unit.core.policestory.javaclass.PoliceStoryJavaClassHandler;
import org.seasar.dbflute.util.DfCollectionUtil;
import org.seasar.dbflute.util.Srl;

/**
 * @author jflute
 */
public class ToolsMigrationFromJavaTest extends UnitContainerTestCase {

    public void test_making() throws Exception {
        policeStoryOfJavaClassChase(new PoliceStoryJavaClassHandler() {
            public void handle(File srcFile, Class<?> clazz) {
                if (clazz.equals(MigrationExample.class)) { // #pending
                    migrateToCSharp(srcFile, clazz);
                }
            }
        });
    }

    protected void migrateToCSharp(File srcFile, Class<?> clazz) {
        MigrationFileLineHandler handler = new MigrationFileLineHandler();
        readLine(srcFile, "UTF-8", handler);
        log(ln() + handler.toCSharpString()); // #pending
    }

    protected static class MigrationFileLineHandler implements FileLineHandler {
        protected boolean _copyrightArea;
        protected List<String> _copyrightList = DfCollectionUtil.newArrayList();
        protected String _packageName;
        protected final List<String> _importList = DfCollectionUtil.newArrayList();
        protected boolean _classCommentArea;
        protected List<String> _classCommentList = DfCollectionUtil.newArrayList();
        protected boolean _classElementArea;
        protected List<String> _classElementList = DfCollectionUtil.newArrayList();

        public void handle(String line) {
            if (_packageName == null && line.equals("/*")) {
                _copyrightList.add(line);
                _copyrightArea = true;
            } else if (_packageName == null && _copyrightArea && line.startsWith(" * ")) {
                _copyrightList.add(line);
            } else if (_packageName == null && _copyrightArea && line.equals(" */")) {
                _copyrightList.add(line);
                _copyrightArea = false;
            } else if (line.startsWith("package ")) {
                _packageName = Srl.rtrim(Srl.substringFirstRear(line, "package "), ";");
            } else if (line.startsWith("import ")) {
                _importList.add(Srl.rtrim(Srl.substringFirstRear(line, "import "), ";"));
            } else if (_packageName != null && line.startsWith("/**")) { // class comment
                // #pending change C# comment
                _classCommentList.add(line);
                _classCommentArea = true;
            } else if (_packageName != null && _classCommentArea && line.startsWith(" * ")) {
                _classCommentList.add(line);
            } else if (_packageName != null && _classCommentArea && line.equals(" */")) {
                _classCommentList.add(line);
                _classCommentArea = false;
            } else if (line.startsWith("public ")) { // class or interface definition
                _classElementList.add(line);
                _classElementArea = true;
            } else if (_classElementArea) {
                _classElementList.add(line);
            } else if (_classElementArea && line.startsWith("}")) {
                _classElementList.add(line);
                _classElementArea = false;
            }
        }

        public String toCSharpString() {
            StringBuilder sb = new StringBuilder();
            for (String line : _copyrightList) {
                sb.append(line).append(ln());
            }
            for (String importClass : _importList) {
                // #pending inner class handling
                String packageOnlyImport = Srl.substringLastFront(importClass, ".");
                sb.append("using ").append(toUpperDotString(packageOnlyImport)).append(";").append(ln());
            }
            if (!_importList.isEmpty()) {
                sb.append(ln());
            }
            sb.append("namespace ").append(toUpperDotString(_packageName)).append(" {").append(ln());
            sb.append(ln());
            for (String line : _classCommentList) {
                sb.append(line).append(ln()); // #pending to CSharp comment
            }
            for (String line : _classElementList) {
                sb.append(line).append(ln()); // #pending many many convert
            }
            sb.append(ln());
            sb.append("}");
            return sb.toString();
        }

        protected String toUpperDotString(String dotString) { // #review needs upper?
            List<String> tokenList = Srl.splitList(dotString, ".");
            StringBuilder sb = new StringBuilder();
            for (String token : tokenList) {
                if (sb.length() > 0) {
                    sb.append(".");
                }
                sb.append(Srl.initCap(token));
            }
            return sb.toString();
            // #pending outsidesql to OutsideSql?
        }

        protected String ln() {
            return "\r\n"; // #review needs CR?
        }
    }
}
