package org.seasar.dbflute.net.migration.tools.handler;

import java.util.Collections;
import java.util.List;
import java.util.Map;

import org.seasar.dbflute.unit.core.filesystem.FileLineHandler;
import org.seasar.dbflute.util.DfCollectionUtil;
import org.seasar.dbflute.util.Srl;

/**
 * @author jflute
 */
public class MigrationFileLineHandler implements FileLineHandler {

    // ===================================================================================
    //                                                                          Definition
    //                                                                          ==========
    protected static final Map<String, String> _toCapCamelWordMap;
    static {
        Map<String, String> map = DfCollectionUtil.newLinkedHashMap();
        map.put("dbflute", "DBFlute");
        map.put("outsidesql", "OutsideSql");
        _toCapCamelWordMap = Collections.unmodifiableMap(map);
    }

    protected static final List<String> _defaultUsingList;
    static {
        List<String> list = DfCollectionUtil.newArrayList();
        list.add("System");
        _defaultUsingList = list;
    }

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
    protected boolean _copyrightArea;
    protected List<String> _copyrightList = DfCollectionUtil.newArrayList();
    protected String _packageName;
    protected final List<String> _importList = DfCollectionUtil.newArrayList();
    protected boolean _classCommentArea;
    protected List<String> _classCommentList = DfCollectionUtil.newArrayList();
    protected boolean _classElementArea;
    protected List<String> _classElementList = DfCollectionUtil.newArrayList();

    // ===================================================================================
    //                                                                       Line Handling
    //                                                                       =============
    public void handle(String line) {
        if (_packageName == null && line.equals("/*")) {
            _copyrightList.add(line);
            _copyrightArea = true;
        } else if (_packageName == null && _copyrightArea && line.startsWith(" * ")) {
            _copyrightList.add(line);
        } else if (_packageName == null && _copyrightArea && line.equals(" */")) {
            _copyrightList.add(line);
            _copyrightArea = false;
        } else if (line.startsWith("package ")) {
            _packageName = Srl.rtrim(Srl.substringFirstRear(line, "package "), ";");
        } else if (line.startsWith("import ")) {
            _importList.add(Srl.rtrim(Srl.substringFirstRear(line, "import "), ";"));
        } else if (_packageName != null && line.startsWith("/**")) { // class comment
            // #pending change C# comment
            _classCommentList.add(line);
            _classCommentArea = true;
        } else if (_packageName != null && _classCommentArea && line.startsWith(" * ")) {
            _classCommentList.add(line);
        } else if (_packageName != null && _classCommentArea && line.equals(" */")) {
            _classCommentList.add(line);
            _classCommentArea = false;
        } else if (line.startsWith("public ")) { // class or interface definition
            _classElementList.add(line);
            _classElementArea = true;
        } else if (_classElementArea) {
            _classElementList.add(line);
        } else if (_classElementArea && line.startsWith("}")) {
            _classElementList.add(line);
            _classElementArea = false;
        }
    }

    // ===================================================================================
    //                                                                        to C# String
    //                                                                        ============
    public String toCSharpString() {
        StringBuilder sb = new StringBuilder();
        for (String line : _copyrightList) {
            sb.append(line).append(ln());
        }
        List<String> defaultusinglist = _defaultUsingList;
        for (String defaultUsing : defaultusinglist) {
            sb.append("using ").append(defaultUsing).append(";").append(ln());
        }
        buildUsingClause(sb);
        sb.append(ln());
        sb.append("namespace ").append(toUpperDotString(_packageName)).append(" {").append(ln());
        sb.append(ln());
        for (String line : _classCommentList) {
            sb.append(line).append(ln()); // #pending to CSharp comment
        }
        for (String line : _classElementList) {
            sb.append(convertClassElement(line)).append(ln()); // #pending many many convert
        }
        sb.append(ln());
        sb.append("}");
        return sb.toString();
    }

    // ===================================================================================
    //                                                                    Namespace/Import
    //                                                                    ================
    private void buildUsingClause(StringBuilder sb) {
        for (String importClass : _importList) {
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

    // ===================================================================================
    //                                                                       Class Element
    //                                                                       =============
    protected String convertClassElement(String line) {
        String work = line;
        if (work.trim().startsWith("for ") && line.contains(" : ")) {
            work = replace(work, "for ", "foreach ");
            work = replace(work, " : ", " in ");
        }
        if (work.contains(" instanceof ")) {
            work = replace(work, " instanceof ", " is ");
        }
        return doConvertClassElementBasic(work);
    }

    protected String doConvertClassElementBasic(String line) {
        return replaceBy(line, _basicClassElementReplaceMap);
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

    // ===================================================================================
    //                                                                            Accessor
    //                                                                            ========
    public List<String> getImportList() {
        return _importList;
    }
}
