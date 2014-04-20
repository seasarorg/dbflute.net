
# ========================================================================================
#                                                                                 Overview
#                                                                                 ========
JavaのDBFluteランタイムからDBFlute.NETランタイムへの移行プロジェクト。


# ========================================================================================
#                                                                              Environment
#                                                                              ===========
# ----------------------------------------------------------
#                                                    Compile
#                                                    -------
M2EなどのMaven管理ができる環境が整っていればビルドすることができます。


# ========================================================================================
#                                                                                     Memo
#                                                                                     ====
# ----------------------------------------------------------
#                                           Method Extension
#                                           ----------------
C#のメソッドエクステンションを使って、標準クラスでもJavaのメソッドが利用できるようにして移行を楽にする。

// 拡張メソッド | C# によるプログラミング入門
http://ufcpp.net/study/csharp/sp3_extension.html

移行に必要なエクステンションの候補は...

<< Java6のStringクラスの多くのメソッド >>
http://docs.oracle.com/javase/jp/6/api/java/lang/String.html

contains(), endsWith(), equals(), equalsIgnoreCase(), hashCode(), indexOf(), lastIndexOf(), length()
, startsWith(), substring(), toLowerCase(), toString(), toUpperCase(), trim() 

<< #pending ちょっとずつ洗い出していきます by jflute >>


# ----------------------------------------------------------
#                                                  Namespace
#                                                  ---------
内部利用のJavaライクなクラスのための Namespace に加えて、
あとは、Java版のDBFluteランタイムと同じ。

DBFlute
 |-JavaLike
 |  |-Extensions
 |  |-Lang
 |  |-Sql
 |  |-Util
 |
 |-(その他、Javaと同じ)


# ----------------------------------------------------------
#                                               Standard API
#                                               ------------
import文で利用されている標準API、ToolsStandardApiResearchTestより
(java.langは取れない...)

java.io.BufferedReader
java.io.BufferedWriter
java.io.ByteArrayInputStream
java.io.ByteArrayOutputStream
java.io.File
java.io.FileFilter
java.io.FileInputStream
java.io.FileNotFoundException
java.io.FileOutputStream
java.io.FilenameFilter
java.io.IOException
java.io.InputStream
java.io.InputStreamReader
java.io.ObjectInputStream
java.io.ObjectOutputStream
java.io.OutputStream
java.io.OutputStreamWriter
java.io.PrintWriter
java.io.Reader
java.io.Serializable
java.io.StringReader
java.io.StringWriter
java.io.UnsupportedEncodingException
java.io.Writer
java.lang.Iterable                             OK
java.lang.String string(C#)+拡張メソッドで対応 #pending 未対応メソッドはNotSupportedException
java.lang.reflect.Array
java.lang.reflect.Constructor
java.lang.reflect.Field
java.lang.reflect.GenericArrayType
java.lang.reflect.InvocationTargetException
java.lang.reflect.Method
java.lang.reflect.Modifier
java.lang.reflect.ParameterizedType
java.lang.reflect.Type
java.lang.reflect.WildcardType
java.math.BigDecimal
java.math.BigInteger
java.net.JarURLConnection
java.net.MalformedURLException
java.net.URL
java.net.URLConnection
java.net.URLDecoder
java.sql.Array
java.sql.Blob
java.sql.CallableStatement
java.sql.Clob
java.sql.Connection
java.sql.DatabaseMetaData
java.sql.Date
java.sql.NClob
java.sql.PreparedStatement
java.sql.Ref
java.sql.ResultSet
java.sql.ResultSetMetaData
java.sql.RowId
java.sql.RowIdLifetime
java.sql.SQLClientInfoException
java.sql.SQLException
java.sql.SQLWarning
java.sql.SQLXML
java.sql.Savepoint
java.sql.Statement
java.sql.Struct
java.sql.Time
java.sql.Timestamp
java.sql.Types
java.text.DateFormat
java.text.DecimalFormat
java.text.DecimalFormatSymbols
java.text.ParseException
java.text.SimpleDateFormat
java.util.ArrayList
java.util.Arrays
java.util.Calendar
java.util.Collection                          OK
java.util.Collections
java.util.Comparator
java.util.Date
java.util.GregorianCalendar
java.util.HashMap
java.util.HashSet
java.util.Iterator                            OK
java.util.LinkedHashMap
java.util.LinkedHashSet
java.util.List                                OK
java.util.ListIterator                        OK
java.util.Locale
java.util.Map
java.util.Map.Entry
java.util.Properties
java.util.Set
java.util.SortedSet
java.util.Stack
java.util.StringTokenizer
java.util.TimeZone
java.util.TreeSet
java.util.UUID
java.util.concurrent.Callable
java.util.concurrent.ConcurrentHashMap
java.util.concurrent.CountDownLatch
java.util.concurrent.ExecutionException
java.util.concurrent.ExecutorService
java.util.concurrent.Executors
java.util.concurrent.Future
java.util.jar.JarFile
java.util.zip.ZipEntry
javax.sql.DataSource

