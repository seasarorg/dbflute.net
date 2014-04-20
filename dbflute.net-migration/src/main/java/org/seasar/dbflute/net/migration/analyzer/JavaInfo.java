package org.seasar.dbflute.net.migration.analyzer;

import java.util.List;

/**
 * @author jflute
 */
public class JavaInfo {

    // ===================================================================================
    //                                                                           Attribute
    //                                                                           =========
    protected final JavaAnalyzer _analyzer;

    // ===================================================================================
    //                                                                         Constructor
    //                                                                         ===========
    public JavaInfo(JavaAnalyzer analyzer) {
        _analyzer = analyzer;
    }

    // ===================================================================================
    //                                                                            Accessor
    //                                                                            ========
    public List<String> getCopyrightList() {
        return _analyzer.getCopyrightList();
    }

    public String getPackageName() {
        return _analyzer.getPackageName();
    }

    public List<String> getImportList() {
        return _analyzer.getImportList();
    }

    public List<String> getClassCommentList() {
        return _analyzer.getClassCommentList();
    }

    public List<String> getClassElementList() {
        return _analyzer.getClassElementList();
    }
}
