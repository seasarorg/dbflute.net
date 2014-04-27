package org.seasar.dbflute.net.migration.unit;

import java.io.File;
import java.io.IOException;
import java.util.Arrays;
import java.util.LinkedHashSet;
import java.util.List;
import java.util.Set;

import org.seasar.dbflute.helper.HandyDate;
import org.seasar.dbflute.infra.manage.refresh.DfRefreshResourceRequest;
import org.seasar.dbflute.unit.core.PlainTestCase;
import org.seasar.dbflute.unit.core.policestory.PoliceStory;

/**
 * @author jflute
 */
public abstract class UnitContainerTestCase extends PlainTestCase {

    // ===================================================================================
    //                                                                          Definition
    //                                                                          ==========
    protected static final Set<Class<?>> outOfMigrationClassSet = new LinkedHashSet<Class<?>>();
    static {
        // #pending later
        outOfMigrationClassSet.add(HandyDate.class);
    }

    // ===================================================================================
    //                                                                        Police Story
    //                                                                        ============
    @Override
    protected PoliceStory createPoliceStory() {
        if (isUseRuntimeDirectPoliceStory()) {
            return new PoliceStory(this, getRuntimeProjectDir());
        } else {
            return super.createPoliceStory();
        }
    }

    protected boolean isUseRuntimeDirectPoliceStory() {
        return false;
    }

    // ===================================================================================
    //                                                                           Directory
    //                                                                           =========
    protected File getRuntimeProjectDir() {
        File workspaceDir = getProjectDir().getParentFile().getParentFile();
        return new File(workspaceDir + "/dbflute/dbflute-runtime/");
    }

    protected File getNetRuntimeProjectDir() throws IOException {
        return new File(getProjectDir().getParentFile().getCanonicalFile() + "/dbflute.net-runtime");
    }

    protected File getNetRuntimeSourceDir() throws IOException {
        return new File(getNetRuntimeProjectDir().getCanonicalPath() + "/DBFluteRuntime");
    }

    // ===================================================================================
    //                                                                    Migration Helper
    //                                                                    ================
    protected boolean isOutOfMigrationClass(Class<?> clazz) {
        return outOfMigrationClassSet.contains(clazz);
    }

    protected void refreshMigrationProject() throws IOException {
        final List<String> projectNameList = Arrays.asList("dbflute.net-migration", "dbflute.net-runtime");
        new DfRefreshResourceRequest(projectNameList, "http://localhost:8386/").refreshResources();
    }
}
