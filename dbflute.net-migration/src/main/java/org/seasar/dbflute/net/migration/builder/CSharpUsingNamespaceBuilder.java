package org.seasar.dbflute.net.migration.builder;

import java.util.Collections;
import java.util.List;
import java.util.Map;

import org.seasar.dbflute.net.migration.analyzer.JavaInfo;
import org.seasar.dbflute.util.DfCollectionUtil;
import org.seasar.dbflute.util.Srl;

/**
 * @author jflute
 */
public class CSharpUsingNamespaceBuilder extends CSharpBuilderBase {

    // ===================================================================================
    //                                                                          Definition
    //                                                                          ==========
    protected static final List<String> _defaultUsingList;
    static {
        List<String> list = DfCollectionUtil.newArrayList();
        list.add("System");
        list.add("DBFlute.JavaLike.Lang");
        list.add("DBFlute.JavaLike.Util");
        _defaultUsingList = list;
    }

    protected static final Map<String, String> _toCapCamelWordMap;
    static {
        Map<String, String> map = DfCollectionUtil.newLinkedHashMap();
        map.put("dbflute", "DBFlute");
        map.put("outsidesql", "OutsideSql");
        map.put("twowaysql", "TwoWaySql");
        _toCapCamelWordMap = Collections.unmodifiableMap(map);
    }

    // ===================================================================================
    //                                                                         Constructor
    //                                                                         ===========
    public CSharpUsingNamespaceBuilder(JavaInfo javaInfo) {
        super(javaInfo);
    }

    // ===================================================================================
    //                                                                               Using
    //                                                                               =====
    public void buildUsingString(StringBuilder sb) {
        doBuildDefaultUsingClause(sb);
        doBuildMappingUsingClause(sb);
    }

    protected void doBuildDefaultUsingClause(StringBuilder sb) {
        List<String> defaultusinglist = _defaultUsingList;
        for (String defaultUsing : defaultusinglist) {
            sb.append("using ").append(defaultUsing).append(";").append(ln());
        }
    }

    protected void doBuildMappingUsingClause(StringBuilder sb) {
        for (String importClass : _javaInfo.getImportList()) {
            String work = importClass;
            if (work.startsWith("java.")) {
                continue;
            }
            if (work.startsWith("org.seasar.dbflute.")) {
                work = replace(work, "org.seasar.dbflute.", "dbflute.");
            }
            if (work.startsWith("org.dbflute.")) {
                work = replace(work, "org.dbflute.", "dbflute.");
            }
            // remove class name and inner class name,
            // and convert to upper tokens
            work = toUpperDotString(removeUpperToken(work));
            sb.append("using ").append(work).append(";").append(ln());
        }
    }

    // ===================================================================================
    //                                                                           Namespace
    //                                                                           =========
    public void buildNamespaceClause(StringBuilder sb) {
        String packageName = _javaInfo.getPackageName();
        sb.append("namespace ").append(toUpperDotString(packageName)).append(" {").append(ln());
    }

    protected String removeUpperToken(String dotString) {
        List<String> tokenList = splitList(dotString, ".");
        StringBuilder sb = new StringBuilder();
        for (String token : tokenList) {
            if (Srl.isInitUpperCase(token)) {
                continue;
            }
            if (sb.length() > 0) {
                sb.append(".");
            }
            sb.append(token);
        }
        return sb.toString();
    }

    protected String toUpperDotString(String dotString) {
        List<String> tokenList = splitList(dotString, ".");
        StringBuilder sb = new StringBuilder();
        for (String token : tokenList) {
            if (sb.length() > 0) {
                sb.append(".");
            }
            sb.append(initCap(replaceBy(token, _toCapCamelWordMap)));
        }
        return sb.toString();
    }
}
