package org.seasar.dbflute.net.migration.builder;

import java.util.List;
import java.util.Map;

import org.seasar.dbflute.net.migration.analyzer.JavaInfo;
import org.seasar.dbflute.util.Srl;

/**
 * @author jflute
 */
public abstract class CSharpBuilderBase {

    // ===================================================================================
    //                                                                           Attribute
    //                                                                           =========
    protected final JavaInfo _javaInfo;

    // ===================================================================================
    //                                                                         Constructor
    //                                                                         ===========
    public CSharpBuilderBase(JavaInfo javaInfo) {
        _javaInfo = javaInfo;
    }

    // ===================================================================================
    //                                                                      General Helper
    //                                                                      ==============
    protected List<String> splitList(String str, String delimiter) {
        return Srl.splitList(str, delimiter);
    }

    protected String replace(String str, String fromStr, String toStr) {
        return Srl.replace(str, fromStr, toStr);
    }

    protected String replaceBy(String str, Map<String, String> fromToMap) {
        return Srl.replaceBy(str, fromToMap);
    }

    protected String initCap(String str) {
        return Srl.initCap(str);
    }

    protected String ln() {
        return "\r\n"; // #review needs CR?
    }
}
