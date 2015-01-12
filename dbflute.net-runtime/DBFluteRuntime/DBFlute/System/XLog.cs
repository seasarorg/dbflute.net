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
using DBFlute.JavaLike;
using DBFlute.JavaLike.Extensions;
using DBFlute.JavaLike.Lang;
using DBFlute.JavaLike.Time;
using DBFlute.JavaLike.Util;
using slf4net;

namespace DBFlute.DfSystem {

/**
 * @author jflute
 */
public class XLog {

    // ===================================================================================
    //                                                                          Definition
    //                                                                          ==========
    /** The logger instance for this class. (NotNull) */
    private static readonly ILogger _log = ILoggerFactory.getLogger(XLog.class);LoggerFactory.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

    protected static boolean _executeStatusLogLevelInfo;
    protected static boolean _loggingInHolidayMood;
    protected static boolean _locked = true;

    // ===================================================================================
    //                                                              Execute-Status Logging
    //                                                              ======================
    public static void log(String msg) { // very internal
        if (_executeStatusLogLevelInfo) {
            _log.Info(msg);
        } else {
            _log.Debug(msg);
        }
    }

    public static boolean isLogEnabled() { // very internal
        if (_loggingInHolidayMood) {
            return false;
        }
        if (_executeStatusLogLevelInfo) {
            return _log.IsInfoEnabled;
        } else {
            return _log.IsDebugEnabled;
        }
    }

    // ===================================================================================
    //                                                                  Logging Adjustment
    //                                                                  ==================
    protected static boolean isExecuteStatusLogLevelInfo() {
        return _executeStatusLogLevelInfo;
    }

    public static void setExecuteStatusLogLevelInfo(boolean executeStatusLogLevelInfo) {
        assertUnlocked();
        if (_log.IsInfoEnabled) {
            _log.Info("...Setting executeStatusLogLevelInfo: " + executeStatusLogLevelInfo);
        }
        _executeStatusLogLevelInfo = executeStatusLogLevelInfo;
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
            _log.Info("...Locking the log object for execute status!");
        }
        _locked = true;
    }

    public static void undoLock() {
        if (!_locked) {
            return;
        }
        if (_log.IsInfoEnabled) {
            _log.Info("...Unlocking the log object for execute status!");
        }
        _locked = false;
    }

    protected static void assertUnlocked() {
        if (!isLocked()) {
            return;
        }
        throw new IllegalStateException("The execute-status log is locked.");
    }
}

}