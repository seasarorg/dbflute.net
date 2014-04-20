package org.seasar.dbflute.net.migration.unit;

import java.io.File;

import org.seasar.dbflute.unit.core.PlainTestCase;
import org.seasar.dbflute.unit.core.policestory.PoliceStory;

/**
 * @author jflute
 */
public abstract class UnitContainerTestCase extends PlainTestCase {

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

    protected File getRuntimeProjectDir() {
        File workspaceDir = getProjectDir().getParentFile().getParentFile();
        return new File(workspaceDir + "/dbflute/dbflute-runtime/");
    }
}
