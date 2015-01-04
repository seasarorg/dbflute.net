package org.seasar.dbflute.net.migration.analyzer;

import java.util.List;

import org.dbflute.util.DfCollectionUtil;
import org.dbflute.util.Srl;

/**
 * @author jflute
 */
public class JavaAnalyzer {

    // ===================================================================================
    //                                                                           Attribute
    //                                                                           =========
    // -----------------------------------------------------
    //                                               Control
    //                                               -------
    protected boolean _copyrightArea;
    protected boolean _classCommentArea;
    protected boolean _classElementArea;

    // -----------------------------------------------------
    //                                                Result
    //                                                ------
    protected final List<String> _copyrightList = DfCollectionUtil.newArrayList();
    protected String _packageName;
    protected final List<String> _importList = DfCollectionUtil.newArrayList();
    protected final List<String> _classCommentList = DfCollectionUtil.newArrayList();
    protected final List<String> _classElementList = DfCollectionUtil.newArrayList();

    // ===================================================================================
    //                                                                        Analyze Line
    //                                                                        ============
    public void analyzeLine(String line) {
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
            _classCommentList.add(line);
            _classCommentArea = true;
        } else if (_packageName != null && _classCommentArea && line.startsWith(" * ")) {
            _classCommentList.add(line);
        } else if (_packageName != null && _classCommentArea && line.equals(" */")) {
            _classCommentList.add(line);
            _classCommentArea = false;
        } else if (line.startsWith("public ")) { // class or interface definition
            _classElementList.add(line); // #pending method definition management
            _classElementArea = true;
        } else if (_classElementArea) {
            _classElementList.add(line);
        } else if (_classElementArea && line.startsWith("}")) {
            _classElementList.add(line);
            _classElementArea = false;
        }
    }

    public JavaInfo toJavaInfo() {
        return new JavaInfo(this);
    }

    // ===================================================================================
    //                                                                            Accessor
    //                                                                            ========
    public List<String> getCopyrightList() {
        return _copyrightList;
    }

    public String getPackageName() {
        return _packageName;
    }

    public List<String> getImportList() {
        return _importList;
    }

    public List<String> getClassCommentList() {
        return _classCommentList;
    }

    public List<String> getClassElementList() {
        return _classElementList;
    }
}
