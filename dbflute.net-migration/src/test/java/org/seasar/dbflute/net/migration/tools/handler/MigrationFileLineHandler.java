package org.seasar.dbflute.net.migration.tools.handler;

import org.dbflute.utflute.core.filesystem.FileLineHandler;
import org.seasar.dbflute.net.migration.analyzer.JavaAnalyzer;
import org.seasar.dbflute.net.migration.analyzer.JavaInfo;
import org.seasar.dbflute.net.migration.builder.CSharpBuilder;

/**
 * @author jflute
 */
public class MigrationFileLineHandler implements FileLineHandler {

    // ===================================================================================
    //                                                                           Attribute
    //                                                                           =========
    protected final JavaAnalyzer _analyzer = new JavaAnalyzer();

    // ===================================================================================
    //                                                                       Line Handling
    //                                                                       =============
    public void handle(String line) {
        _analyzer.analyzeLine(line);
    }

    // ===================================================================================
    //                                                                            Accessor
    //                                                                            ========
    public String toCSharpString() {
        return new CSharpBuilder(toJavaInfo()).toCSharpString();
    }

    public JavaInfo toJavaInfo() {
        return _analyzer.toJavaInfo();
    }
}
