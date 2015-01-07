/*
 * Copyright 2014-2015 the original author or authors.
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *     http://www.apache.org/licenses/LICENSE-2.0
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND,
 * either express or implied. See the License for the specific language
 * governing permissions and limitations under the License.
 */
using System;
using DBFlute.JavaLike.Lang;
using DBFlute.JavaLike.Util;
using slf4net;

namespace DBFlute.DfSystem {

/**
 * @author jflute
 */
public class QLog {

    // ===================================================================================
    //                                                                          Definition
    //                                                                          ==========
    /** The logger instance for this class. (NotNull) */
    private static readonly ILogger _log = LoggerFactory.GetLogger(typeof(QLog));

    protected static boolean _queryLogLevelInfo;
    protected static boolean _loggingInHolidayMood;
    protected static boolean _locked = true;

    // ===================================================================================
    //                                                                       Query Logging
    //                                                                       =============
    public static void log(String sql) { // very Internal
        if (_queryLogLevelInfo) {
            _log.Info(sql);
        } else {
            _log.Debug(sql);
        }
    }

    public static boolean isLogEnabled() { // very internal
        if (_loggingInHolidayMood) {
            return false;
        }
        if (_queryLogLevelInfo) {
            return _log.IsInfoEnabled;
        } else {
            return  _log.IsDebugEnabled;
        }
    }

    // ===================================================================================
    //                                                                  Logging Adjustment
    //                                                                  ==================
    protected static boolean isQueryLogLevelInfo() {
        return _queryLogLevelInfo;
    }

    public static void setQueryLogLevelInfo(boolean queryLogLevelInfo) {
        assertUnlocked();
        if (_log.IsInfoEnabled) {
            _log.Info("...Setting queryLogLevelInfo: " + queryLogLevelInfo);
        }
        _queryLogLevelInfo = queryLogLevelInfo;
        doLock(); // auto-lock here, because of deep world
    }

    protected static boolean isLoggingInHolidayMood() {
        return _loggingInHolidayMood;
    }

    public static void setLoggingInHolidayMood(boolean loggingInHolidayMood) {
        assertUnlocked();
        if (_log.IsInfoEnabled) {
            _log.Info("...Setting loggingInHolidayMood: " + loggingInHolidayMood);
        }
        _loggingInHolidayMood = loggingInHolidayMood;
        doLock(); // auto-lock here, because of deep world
    }

    // ===================================================================================
    //                                                                        Logging Lock
    //                                                                        ============
    public static boolean isLocked() {
        return _locked;
    }

    public static void doLock() {
        if (_locked) {
            return;
        }
        if (_log.IsInfoEnabled) {
            _log.Info("...Locking the log object for query!");
        }
        _locked = true;
    }

    public static void undoLock() {
        if (!_locked) {
            return;
        }
        if (_log.IsInfoEnabled) {
            _log.Info("...Unlocking the log object for query!");
        }
        _locked = false;
    }

    protected static void assertUnlocked() {
        if (!isLocked()) {
            return;
        }
        throw new IllegalStateException("The query log is locked.");
    }
}

}