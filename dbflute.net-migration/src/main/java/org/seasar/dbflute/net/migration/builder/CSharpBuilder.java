package org.seasar.dbflute.net.migration.builder;

import java.util.Collections;
import java.util.Map;

import org.seasar.dbflute.net.migration.analyzer.JavaInfo;
import org.seasar.dbflute.util.DfCollectionUtil;

/**
 * @author jflute
 */
public class CSharpBuilder extends CSharpBuilderBase {

    // ===================================================================================
    //                                                                          Definition
    //                                                                          ==========
    protected static final Map<String, String> _basicClassElementReplaceMap;
    static {
        Map<String, String> map = DfCollectionUtil.newLinkedHashMap();
        map.put("static final ", "static readonly ");
        map.put("public final ", "public readonly ");
        map.put("protected final ", "protected readonly ");
        map.put("private final ", "private readonly ");
        map.put("boolean ", "bool ");
        map.put("Integer ", "int? ");
        _basicClassElementReplaceMap = Collections.unmodifiableMap(map);
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
        return sb.toString();
    }

    protected void buildCopyright(StringBuilder sb) {
        for (String line : _javaInfo.getCopyrightList()) {
            sb.append(line).append(ln());
        }
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
