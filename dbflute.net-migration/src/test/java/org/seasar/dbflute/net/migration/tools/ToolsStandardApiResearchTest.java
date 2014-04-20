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
import java.util.Set;
import java.util.TreeSet;

import org.seasar.dbflute.net.migration.tools.handler.MigrationFileLineHandler;
import org.seasar.dbflute.net.migration.unit.UnitContainerTestCase;
import org.seasar.dbflute.unit.core.policestory.PoliceStory;
import org.seasar.dbflute.unit.core.policestory.javaclass.PoliceStoryJavaClassHandler;

/**
 * @author jflute
 */
public class ToolsStandardApiResearchTest extends UnitContainerTestCase {

    @Override
    protected PoliceStory createPoliceStory() {
        File workspaceDir = getProjectDir().getParentFile().getParentFile();
        return new PoliceStory(this, new File(workspaceDir + "/dbflute/dbflute-runtime/"));
    }

    public void test_research() throws Exception {
        final Set<String> standardApiSet = new TreeSet<String>();
        policeStoryOfJavaClassChase(new PoliceStoryJavaClassHandler() {
            public void handle(File srcFile, Class<?> clazz) {
                MigrationFileLineHandler handler = new MigrationFileLineHandler();
                readLine(srcFile, "UTF-8", handler);
                List<String> importList = handler.getImportList();
                for (String importClass : importList) {
                    if (importClass.startsWith("java")) {
                        standardApiSet.add(importClass);
                    }
                }
            }
        });
        StringBuilder sb = new StringBuilder();
        for (String standardApi : standardApiSet) {
            sb.append(ln()).append(standardApi);
        }
        log(sb.toString());
    }
}
