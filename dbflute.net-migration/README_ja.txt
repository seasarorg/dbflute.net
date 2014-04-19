
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




