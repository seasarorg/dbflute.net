package org.seasar.dbflute.net.migration.builder;

import java.util.Collections;
import java.util.Map;

import org.dbflute.util.DfCollectionUtil;
import org.seasar.dbflute.net.migration.analyzer.JavaInfo;

/**
 * @author jflute
 */
public class CSharpBuilder extends CSharpBuilderBase {

    // ===================================================================================
    //                                                                          Definition
    //                                                                          ==========
    protected static final Map<String, String> _wholeFinallyReplaceMap;
    static {
        Map<String, String> map = DfCollectionUtil.newLinkedHashMap();
        map.put("Org.DBFlute", "DBFlute");
        map.put("Org.Slf4j", "slf4net");
        map.put("System.currentTimeMillis()", "JavaLikeSystem.currentTimeMillis()");
        _wholeFinallyReplaceMap = Collections.unmodifiableMap(map);
    }

    // ===================================================================================
    //                                                                         Constructor
    //                                                                         ===========
    public CSharpBuilder(JavaInfo javaInfo) {
        super(javaInfo);
    }

    // ===================================================================================
    //                                                                        to C# String
    //                                                                        ============
    public String toCSharpString() {
        StringBuilder sb = new StringBuilder();
        buildCopyright(sb);
        buildUsingClause(sb);

        sb.append(ln());
        buildNamespaceClause(sb);

        sb.append(ln());
        buildClassContents(sb);

        sb.append(ln());
        sb.append("}"); // Namespace closing
        return doConvertWholeFinally(sb.toString());
    }

    protected void buildCopyright(StringBuilder sb) {
        for (String line : _javaInfo.getCopyrightList()) {
            sb.append(line).append(ln());
        }
    }

    protected String doConvertWholeFinally(String work) {
        if (work == null) {
            return null;
        }
        return replaceBy(work, _wholeFinallyReplaceMap);
    }

    // ===================================================================================
    //                                                                   Using / Namespace
    //                                                                   =================
    protected void buildUsingClause(StringBuilder sb) {
        createUsingNamespaceBuilder().buildUsingString(sb);
    }

    protected void buildNamespaceClause(StringBuilder sb) {
        createUsingNamespaceBuilder().buildNamespaceClause(sb);
    }

    protected CSharpUsingNamespaceBuilder createUsingNamespaceBuilder() {
        return new CSharpUsingNamespaceBuilder(_javaInfo);
    }

    // ===================================================================================
    //                                                                      Class Contents
    //                                                                      ==============
    protected void buildClassContents(StringBuilder sb) {
        new CSharpClassContentsBuilder(_javaInfo).buildClassContents(sb);
    }
}
