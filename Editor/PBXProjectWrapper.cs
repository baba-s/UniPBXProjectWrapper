using System;
using UnityEditor.iOS.Xcode;

namespace Kogane
{
	/// <summary>
	/// PBXProject のラッパークラス
	/// </summary>
	public sealed class PBXProjectWrapper : IDisposable
	{
		//================================================================================
		// 変数(readonly)
		//================================================================================
		private readonly PBXProject m_project;
		private readonly string     m_projectPath;
		private readonly string     m_targetGuid;

		//================================================================================
		// 関数
		//================================================================================
		/// <summary>
		/// 指定されたパスに存在するプロジェクトを読み込みます
		/// </summary>
		public PBXProjectWrapper( string buildPath )
		{
			m_projectPath = PBXProject.GetPBXProjectPath( buildPath );
			m_project     = new PBXProject();

			m_project.ReadFromFile( m_projectPath );

			m_targetGuid = m_project.GetUnityMainTargetGuid();
		}

		/// <summary>
		/// プロジェクトを保存します
		/// </summary>
		public void Dispose()
		{
			m_project.WriteToFile( m_projectPath );
		}

		/// <summary>
		/// DEBUG_INFORMATION_FORMAT を設定します
		/// </summary>
		public void SetDebugInformationFormat( bool withDsym )
		{
			var value = withDsym ? "dwarf-with-dsym" : "dwarf";
			SetBuildProperty( "DEBUG_INFORMATION_FORMAT", value );
		}

		/// <summary>
		/// DEBUGGING_SYMBOLS を設定します
		/// </summary>
		public void SetDebuggingSymbols( bool isYes )
		{
			var value = isYes ? "YES" : "NO";
			SetBuildProperty( "DEBUGGING_SYMBOLS", value );
		}

		/// <summary>
		/// ENABLE_BITCODE を設定します
		/// </summary>
		public void SetEnableBitcode( bool isYes )
		{
			var value = isYes ? "YES" : "NO";
			SetBuildProperty( "ENABLE_BITCODE", value );
		}

		/// <summary>
		/// GCC_GENERATE_DEBUGGING_SYMBOLS を設定します
		/// </summary>
		public void SetGccGenerateDebuggingSymbols( bool isYes )
		{
			var value = isYes ? "YES" : "NO";
			SetBuildProperty( "GCC_GENERATE_DEBUGGING_SYMBOLS", value );
		}

		/// <summary>
		/// ONLY_ACTIVE_ARCH を設定します
		/// </summary>
		public void SetOnlyActiveArch( bool isYes )
		{
			var value = isYes ? "YES" : "NO";
			SetBuildProperty( "ONLY_ACTIVE_ARCH", value );
		}

		/// <summary>
		/// ビルドプロパティを設定します
		/// </summary>
		public void SetBuildProperty( string name, string value )
		{
			m_project.SetBuildProperty( m_targetGuid, name, value );
		}
	}
}