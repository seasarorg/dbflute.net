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
    //                                                                           Attribute
    //                                                                           =========
    protected boolean _foundOverride;

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
            final String classElement = convertClassElement(line);
            if (classElement != null) {
                sb.append(classElement).append(ln());
            }
        }
    }

    // ===================================================================================
    //                                                                     Convert Element
    //                                                                     ===============
    protected String convertClassElement(String line) {
        String work = line;
        work = doConvertOverride(line, work);
        work = doConvertForeach(line, work);
        work = doConvertInstanceOf(line, work);
        return doConvertBasicElement(line, work);
    }

    protected String doConvertOverride(String line, String work) {
        if (work != null && work.trim().startsWith("@Override")) {
            _foundOverride = true;
            return null;
        } else {
            if (_foundOverride && isMethodLine(line)) {
                _foundOverride = false;
                return replace(replace(work, "public ", "public override "), "protected ", "protected override ");
            }
        }
        return work;
    }

    protected boolean isMethodLine(String line) {
        final String trimmed = line.trim();
        return trimmed.startsWith("p") && trimmed.contains("(") && trimmed.endsWith(") {");
    }

    protected String doConvertForeach(String line, String work) {
        if (work != null && work.trim().startsWith("for ") && line.contains(" : ")) {
            return replace(replace(work, "for ", "foreach "), " : ", " in ");
        }
        return work;
    }

    protected String doConvertInstanceOf(String line, String work) {
        if (work != null && work.contains(" instanceof ")) {
            return replace(work, " instanceof ", " is ");
        }
        return work;
    }

    // -----------------------------------------------------
    //                                                 Basic
    //                                                 -----
    protected String doConvertBasicElement(String line, String work) {
        if (work == null) {
            return null;
        }
        return replaceBy(work, _basicClassElementReplaceMap);
    }
}
