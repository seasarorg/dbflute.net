/*
 * Copyright 2004-2014 the Seasar Foundation and the Others.
 *
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 *     http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND,
 * either express or implied. See the License for the specific language
 * governing permissions and limitations under the License.
 */
package org.seasar.dbflute.net.migration.example;

import java.util.Date;
import java.util.List;

import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.seasar.dbflute.helper.HandyDate;
import org.seasar.dbflute.util.DfTypeUtil;

/**
 * @author jflute
 */
public class MigrationExample {

    private static final Log LOG = LogFactory.getLog(MigrationExample.class);

    protected static final String KEY = "foo";

    protected Object _object;
    protected String _string;
    protected Integer _integer;
    protected Long _long;
    protected Date _utilDate;
    protected int _primitiveInt;
    protected long _primitiveLong;
    protected boolean _primitiveBoolean;
    protected List<String> _stringList;

    public void publicMethodNoReturnNoArg() {
        _utilDate = new HandyDate("2014-04-18").getDate();
        for (String string : _stringList) {
            LOG.debug(string);
        }
        if (_object instanceof String) {
            LOG.debug("foo");
        }
    }

    @Override
    public String toString() {
        StringBuilder sb = new StringBuilder();
        sb.append(DfTypeUtil.toClassTitle(this));
        sb.append(":{");
        sb.append(_string);
        sb.append("}");
        return sb.toString();
    }
}
