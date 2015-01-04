package org.seasar.dbflute.net.migration.unit;

import java.io.File;
import java.io.IOException;
import java.util.Arrays;
import java.util.LinkedHashSet;
import java.util.List;
import java.util.Set;

import org.dbflute.helper.HandyDate;
import org.dbflute.helper.mapstring.MapListFile;
import org.dbflute.infra.manage.refresh.DfRefreshResourceRequest;
import org.dbflute.utflute.core.PlainTestCase;
import org.dbflute.utflute.core.policestory.PoliceStory;

/**
 * @author jflute
 */
public abstract class UnitContainerTestCase extends PlainTestCase {

    // ===================================================================================
    //                                                                          Definition
    //                                                                          ==========
    protected static final Set<String> outOfMigrationPackageSet = new LinkedHashSet<String>();
    static {
        outOfMigrationPackageSet.add("org.seasar.dbflute.dbmeta.alter");
        outOfMigrationPackageSet.add("org.seasar.dbflute.infra");
        outOfMigrationPackageSet.add("org.seasar.dbflute.helper.filesystem");
        outOfMigrationPackageSet.add("org.seasar.dbflute.helper.jprop");
        outOfMigrationPackageSet.add("org.seasar.dbflute.helper.process");
        outOfMigrationPackageSet.add("org.seasar.dbflute.helper.secretary");
        outOfMigrationPackageSet.add("org.seasar.dbflute.helper.thread");
        outOfMigrationPackageSet.add("org.seasar.dbflute.helper.token");
    }
    protected static final Set<Class<?>> outOfMigrationClassSet = new LinkedHashSet<Class<?>>();
    static {
        // #pending later
        outOfMigrationClassSet.add(HandyDate.class);
        outOfMigrationClassSet.add(MapListFile.class);
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
        return new File(workspaceDir + "/dbflute-core/dbflute-runtime/");
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
        for (String pkg : outOfMigrationPackageSet) {
            if (clazz.getPackage().getName().startsWith(pkg)) {
                return true;
            }
        }
        return outOfMigrationClassSet.contains(clazz);
    }

    protected void refreshMigrationProject() throws IOException {
        final List<String> projectNameList = Arrays.asList("dbflute.net-migration", "dbflute.net-runtime");
        new DfRefreshResourceRequest(projectNameList, "http://localhost:8386/").refreshResources();
    }
}
