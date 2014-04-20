package org.seasar.dbflute.net.migration.builder;

import java.util.Collections;
import java.util.Map;

import org.seasar.dbflute.net.migration.analyzer.JavaInfo;
import org.seasar.dbflute.util.DfCollectionUtil;

/**
 * @author jflute
 */
public class CSharpClassContentsBuilder extends CSharpBuilderBase {

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
    public CSharpClassContentsBuilder(JavaInfo javaInfo) {
        super(javaInfo);
    }

    // ===================================================================================
    //                                                                      Class Contents
    //                                                                      ==============
    public void buildClassContents(StringBuilder sb) {
        doBuildClassCommentClause(sb);
        doBuildClassElementClause(sb);
    }

    protected void doBuildClassCommentClause(StringBuilder sb) {
        for (String line : _javaInfo.getClassCommentList()) {
            sb.append(line).append(ln()); // #pending to CSharp comment
        }
    }

    protected void doBuildClassElementClause(StringBuilder sb) {
        for (String line : _javaInfo.getClassElementList()) {
            sb.append(convertClassElement(line)).append(ln());
        }
    }

    // ===================================================================================
    //                                                                     Convert Element
    //                                                                     ===============
    protected String convertClassElement(String line) {
        String work = line;
        work = doConvertForeach(line, work);
        work = doConvertInstanceOf(work);
        return doConvertBasicElement(work);
    }

    protected String doConvertForeach(String line, String work) {
        if (work.trim().startsWith("for ") && line.contains(" : ")) {
            work = replace(work, "for ", "foreach ");
            work = replace(work, " : ", " in ");
        }
        return work;
    }

    protected String doConvertInstanceOf(String work) {
        if (work.contains(" instanceof ")) {
            work = replace(work, " instanceof ", " is ");
        }
        return work;
    }

    // -----------------------------------------------------
    //                                                 Basic
    //                                                 -----
    protected String doConvertBasicElement(String line) {
        return replaceBy(line, _basicClassElementReplaceMap);
    }
}
