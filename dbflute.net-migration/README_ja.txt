
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
#                                                                  Migration Specification
#                                                                  =======================
# ----------------------------------------------------------
#                                                   Overview
#                                                   --------
Method Extension と Java っぽいインターフェースのクラス (JavaLike) を作って、
できるだけJavaのコードがそのまま移植できるようにします。
そして、文法的な部分での変換は、Java to C# のコンバーターを作って移行します。
最後は、手作業。(あまり定型的なものはできるだけコンバーターで吸収)


# ----------------------------------------------------------
#                                           Method Extension
#                                           ----------------
C#のメソッドエクステンションを使って、標準クラスでもJavaのメソッドが利用できるようにして移行を楽にする。

// 拡張メソッド | C# によるプログラミング入門
http://ufcpp.net/study/csharp/sp3_extension.html

例えば、移行に必要なエクステンションの候補は...

// Java6のStringクラスの多くのメソッド
http://docs.oracle.com/javase/jp/6/api/java/lang/String.html

o String
o StringBuilder
o Object
o int?
o long?


# ----------------------------------------------------------
#                                                  Java Like
#                                                  ---------
Javaと同じクラス名、Javaとメソッド名で、C#のクラスをラップしたアダプターを作る。
既存のJavaLikeクラスを参考にする。

o boolean, Integer, Long
o Collection (List, HashMap, Arrays, ConcurrentHashMap, ...)
o Exception (IllegalStateException, ...)
o Reflection (Class, Method, ...)
o JDBC for ADO.NET (PreparedStatement, ResultSet, ...)
o 基本型吸収 (BigDecimal, ...)


# ----------------------------------------------------------
#                                                  Converter
#                                                  ---------
DBFluteランタイムのクラスを全てフィルターして、7割8割くらいのC#コードの土台を作る。

o インターフェースメソッドをabstractで受けなきゃいけない？
o Genericの書き方の変換が大変そう


# ----------------------------------------------------------
#                                                  Namespace
#                                                  ---------
内部利用のJavaライクなクラスのための Namespace に加えて、
あとは、Java版のDBFluteランタイムと同じ。

DBFlute
 |-JavaLike
 |  |-Lang
 |  |-Sql
 |  |-Util
 |
 |-(その他、Javaと同じ)


# ----------------------------------------------------------
#                                            Research Report
#                                            ---------------
dbflute.net-migration/research_report.txt には、移行調査したレポートが出力されています。
Java側で import されているクラスと C# にて作った JavaLike クラスの対応表(進捗付き)のようなものです。

[o] java.util.List            {178: AbstractBehaviorReadable, AbstractBehaviorWritable, BehaviorWritable, DtoMapper, EntityListSetupper, InsertOption, LoadReferrerOption, ...}
   -> JavaLike/Util/List.cs

[x] java.util.Properties      {  3: JavaPropertiesReader, JavaPropertiesResult, NotClosingConnectionWrapper}
[v] java.lang.Object
   -> JavaLike/Lang/ObjectExtension.cs
      // #pending getClassメソッドの対応

o List に対応する C# クラスが存在していて、保留事項もない (Javaでは178クラスから参照されている)
o Properties に対応する C# クラスがまだ存在せず、実装が必要 (Javaでは3クラスから参照されている)
o Object に対応する C# クラスが存在しているが、まだ保留事項がある (java.langは参照情報が取れない)

<< 左のマーク >>
[o]: 対応クラスあり、保留なし
[v]: 対応クラスあり、保留あり (#pendingがある)
[x]: 対応クラスなし、実装しなきゃ！
[n]: 移行対象外 (参照クラスが全て移行対象外)

<< Javaで参照してるクラスたち >>
{178: クラス名, ...}という形式で右側に表示されます。
ただし、java.lang パッケージは解析不能なので情報がありません。
あまりに多いとつらいので、120文字くらい切っています。
移行対象外の場合は「HandyDate(n)」というようにクラスの後ろに(n)が付きます。

<< インナークラス >>
インナークラスは一覧されません。
所属しているクラスの中で実装されることを想定しています。

<< Extension >>
そのJavaクラスの移行は、JavaLikeクラスで対応するか、Method Extension で対応するか、大きく二つに分かれます。
例えば Object は、Method Extension で対応するので、ファイル名が ObjectExtension.cs となっています。
