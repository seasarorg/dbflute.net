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
using DBFlute.DfSystem.Provider;
using slf4net;

namespace DBFlute.DfSystem {

/**
 * @author jflute
 */
public class DBFluteSystem {

    // ===================================================================================
    //                                                                          Definition
    //                                                                          ==========
    /** The logger instance for this class. (NotNull) */
    private static readonly ILogger _log = ILoggerFactory.getLogger(DBFluteSystem.class);LoggerFactory.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

    // ===================================================================================
    //                                                                    Option Attribute
    //                                                                    ================
    /**
     * The provider of current date for DBFlute system. <br>
     * e.g. AccessContext might use this (actually, very very rare case) <br>
     * (NullAllowed: if null, server date might be used)
     */
    protected static DfCurrentDateProvider _currentDateProvider;

    /**
     * The provider of final default locale for DBFlute system. <br>
     * e.g. DisplaySql, Date conversion, LocalDate mapping and so on... <br>
     * (NullAllowed: if null, server locale might be used)
     */
    protected static DfFinalLocaleProvider _finalLocaleProvider;

    /**
     * The provider of final default time-zone for DBFlute system. <br>
     * e.g. DisplaySql, Date conversion, LocalDate mapping and so on... <br>
     * (NullAllowed: if null, server zone might be used)
     */
    protected static DfFinalDBFlute.JavaLike.Util.TimeZoneProvider _finalDBFlute.JavaLike.Util.TimeZoneProvider;

    /** Is this system adjustment locked? */
    protected static boolean _locked = true;

    // ===================================================================================
    //                                                                        Current Time
    //                                                                        ============
    // #dateParade
    /**
     * Get current local date. (server date if no provider)
     * @return The new-created local date instance as current date. (NotNull)
     */
    public static LocalDate currentLocalDate() {
        return currentZonedDateTime().toLocalDate();
    }

    /**
     * Get current local date-time. (server date if no provider)
     * @return The new-created local date instance as current date. (NotNull)
     */
    public static LocalDateTime currentLocalDateTime() {
        return currentZonedDateTime().toLocalDateTime();
    }

    /**
     * Get current zoned date-time. (server date if no provider)
     * @return The new-created zoned date instance as current date. (NotNull)
     */
    public static ZonedDateTime currentZonedDateTime() {
        final DBFlute.JavaLike.Util.TimeZone timeZone = getFinalDBFlute.JavaLike.Util.TimeZone();
        return ZonedDateTime.ofInstant(currentDate().toInstant(), timeZone.toZoneId());
    }

    /**
     * Get current date. (server date if no provider)
     * @return The new-created date instance as current date. (NotNull)
     */
    public static Date currentDate() {
        return new Date(currentTimeMillis());
    }

    /**
     * Get current time-stamp. (server date if no provider)
     * @return The new-created time-stamp instance as current date. (NotNull)
     */
    public static Timestamp currentTimestamp() {
        return new Timestamp(currentTimeMillis());
    }

    /**
     * Get current date as milliseconds. (server date if no provider)
     * @return The long value as milliseconds.
     */
    public static long currentTimeMillis() {
        final long millis;
        if (_currentDateProvider != null) {
            millis = _currentDateProvider.currentTimeMillis();
        } else {
            millis = JavaLikeSystem.currentTimeMillis();
        }
        return millis;
    }

    // ===================================================================================
    //                                                                        Final Locale
    //                                                                        ============
    /**
     * Get the final default locale for DBFlute system. <br>
     * basically for e.g. DisplaySql, Date conversion, LocalDate mapping and so on...
     * @return The final default locale for DBFlute system. (NotNull: if no provider, server locale)
     */
    public static Locale getFinalLocale() {
        return _finalLocaleProvider != null ? _finalLocaleProvider.provide() : Locale.getDefault();
    }

    // ===================================================================================
    //                                                                      Final DBFlute.JavaLike.Util.TimeZone
    //                                                                      ==============
    /**
     * Get the final default time-zone for DBFlute system. <br>
     * basically for e.g. DisplaySql, Date conversion, LocalDate mapping and so on...
     * @return The final default time-zone for DBFlute system. (NotNull: if no provider, server zone)
     */
    public static DBFlute.JavaLike.Util.TimeZone getFinalDBFlute.JavaLike.Util.TimeZone() {
        return _finalDBFlute.JavaLike.Util.TimeZoneProvider != null ? _finalDBFlute.JavaLike.Util.TimeZoneProvider.provide() : DBFlute.JavaLike.Util.TimeZone.getDefault();
    }

    // ===================================================================================
    //                                                                      Line Separator
    //                                                                      ==============
    /**
     * Get basic line separator for DBFlute process.
     * @return The string of line separator. (NotNull)
     */
    public static String ln() {
        return "\n"; // LF is basic here
        // /- - - - - - - - - - - - - - - - - - - - - - - - - - -
        // The 'CR + LF' causes many trouble all over the world.
        //  e.g. Oracle stored procedure
        // - - - - - - - - - -/
    }

    // unused on DBFlute
    //public static String getSystemLn() {
    //    return System.getProperty("line.separator");
    //}

    // ===================================================================================
    //                                                                   System Adjustment
    //                                                                   =================
    // -----------------------------------------------------
    //                                          Current Date
    //                                          ------------
    public static boolean hasCurrentDateProvider() {
        return _currentDateProvider != null;
    }

    public static void setCurrentDateProvider(DfCurrentDateProvider currentDateProvider) {
        assertUnlocked();
        if (_log.IsInfoEnabled) {
            _log.Info("...Setting currentDateProvider: " + currentDateProvider);
        }
        _currentDateProvider = currentDateProvider;
        doLock(); // auto-lock here, because of deep world
    }

    // -----------------------------------------------------
    //                                          Final Locale
    //                                          ------------
    public static boolean hasFinalLocaleProvider() {
        return _finalDBFlute.JavaLike.Util.TimeZoneProvider != null;
    }

    public static void setFinalLocaleProvider(DfFinalLocaleProvider finalLocaleProvider) {
        assertUnlocked();
        if (_log.IsInfoEnabled) {
            _log.Info("...Setting finalLocaleProvider: " + finalLocaleProvider);
        }
        _finalLocaleProvider = finalLocaleProvider;
        doLock(); // auto-lock here, because of deep world
    }

    // -----------------------------------------------------
    //                                        Final DBFlute.JavaLike.Util.TimeZone
    //                                        --------------
    public static boolean hasFinalDBFlute.JavaLike.Util.TimeZoneProvider() {
        return _finalDBFlute.JavaLike.Util.TimeZoneProvider != null;
    }

    public static void setFinalDBFlute.JavaLike.Util.TimeZoneProvider(DfFinalDBFlute.JavaLike.Util.TimeZoneProvider finalDBFlute.JavaLike.Util.TimeZoneProvider) {
        assertUnlocked();
        if (_log.IsInfoEnabled) {
            _log.Info("...Setting finalDBFlute.JavaLike.Util.TimeZoneProvider: " + finalDBFlute.JavaLike.Util.TimeZoneProvider);
        }
        _finalDBFlute.JavaLike.Util.TimeZoneProvider = finalDBFlute.JavaLike.Util.TimeZoneProvider;
        doLock(); // auto-lock here, because of deep world
    }

    // ===================================================================================
    //                                                                         System Lock
    //                                                                         ===========
    public static void doLock() {
        if (_locked) {
            return;
        }
        if (_log.IsInfoEnabled) {
            _log.Info("...Locking the DBFlute system");
        }
        _locked = true;
    }

    public static void undoLock() {
        if (!_locked) {
            return;
        }
        if (_log.IsInfoEnabled) {
            _log.Info("...Unlocking the DBFlute system");
        }
        _locked = false;
    }

    public static boolean isLocked() {
        return _locked;
    }

    protected static void assertUnlocked() {
        if (!isLocked()) {
            return;
        }
        throw new IllegalStateException("The DBFlute system is locked.");
    }
}

}