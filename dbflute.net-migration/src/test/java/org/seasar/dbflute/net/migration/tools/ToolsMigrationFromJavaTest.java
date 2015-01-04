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

import org.dbflute.utflute.core.policestory.javaclass.PoliceStoryJavaClassHandler;
import org.seasar.dbflute.net.migration.example.MigrationExample;
import org.seasar.dbflute.net.migration.tools.handler.MigrationFileLineHandler;
import org.seasar.dbflute.net.migration.unit.UnitContainerTestCase;

/**
 * @author jflute
 */
public class ToolsMigrationFromJavaTest extends UnitContainerTestCase {

    @Override
    protected boolean isUseRuntimeDirectPoliceStory() {
        // #pending not yet, uses example test for now
        //return true;
        return false;
    }

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
}
