﻿using System;
using System.Reflection;
using System.Resources;
using System.Runtime.InteropServices;
using System.Windows;

// アセンブリに関する一般情報は以下の属性セットをとおして制御されます。
// アセンブリに関連付けられている情報を変更するには、
// これらの属性値を変更してください。
[assembly: AssemblyTitle("MATH.SC (仮称) for Windows Desktop")]
[assembly: AssemblyDescription("TRIAL VERSION (PRE ALPHA)")]
[assembly: AssemblyConfiguration("")]
[assembly: AssemblyCompany("danmaq / DAYS PRODUCTION")]
[assembly: AssemblyProduct("MATH.SC (仮称)")]
[assembly: AssemblyCopyright("Copyright © 2015 danmaq / DAYS PRODUCTION all rights reserved.")]
[assembly: AssemblyTrademark("")]
[assembly: AssemblyCulture("")]

// ComVisible を false に設定すると、その型はこのアセンブリ内で COM コンポーネントから
// 参照不可能になります。COM からこのアセンブリ内の型にアクセスする場合は、
// その型の ComVisible 属性を true に設定してください。
[assembly: ComVisible(false)]

//ローカライズ可能なアプリケーションのビルドを開始するには、
//.csproj ファイルの <UICulture>CultureYouAreCodingWith</UICulture> を
//<PropertyGroup> 内部で設定します。たとえば、
//ソース ファイルで英語を使用している場合、<UICulture> を en-US に設定します。次に、
//下の NeutralResourceLanguage 属性のコメントを解除します。下の行の "en-US" を
//プロジェクト ファイルの UICulture 設定と一致するよう更新します。

//[assembly: NeutralResourcesLanguage("en-US", UltimateResourceFallbackLocation.Satellite)]


[assembly: ThemeInfo(
	ResourceDictionaryLocation.None, //テーマ固有のリソース ディクショナリが置かれている場所
									 //(リソースがページ、
									 //またはアプリケーション リソース ディクショナリに見つからない場合に使用されます)
	ResourceDictionaryLocation.SourceAssembly //汎用リソース ディクショナリが置かれている場所
											  //(リソースがページ、
											  //アプリケーション、またはいずれのテーマ固有のリソース ディクショナリにも見つからない場合に使用されます)
)]


// アセンブリのバージョン情報は、以下の 4 つの値で構成されています:
//
//      Major Version
//      Minor Version 
//      Build Number
//      Revision
//
// すべての値を指定するか、下のように '*' を使ってビルドおよびリビジョン番号を 
// 既定値にすることができます:
// [assembly: AssemblyVersion("1.0.*")]
[assembly: AssemblyVersion("0.2.0.*")]
[assembly: AssemblyFileVersion("0.2.0.23")]
[assembly: NeutralResourcesLanguage("ja-JP")]
[assembly: Guid("c5d62caf-a7c0-445f-8fa8-aba6625fba6d")]

[assembly: CLSCompliant(false)]
