using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using MC.Common.Properties;
using MC.Common.Utils;

namespace MC.Common.Collection
{
	/// <summary>
	/// サービス コンテナ。
	/// 任意の参照型を登録できます。
	/// </summary>
	public sealed class ServiceContainer : IServiceProvider, IDisposable
	{

		/// <summary>登録されたサービスの件数を取得します。</summary>
		public int Count
		{
			get
			{
				return Container.Count;
			}
		}

		/// <summary>コンテナ本体となる辞書を取得します。</summary>
		private Dictionary<Type, object> Container
		{
			get;
		}
		= new Dictionary<Type, object>();

		/// <summary>
		/// サービスを追加します。
		/// </summary>
		/// <param name="serviceType">サービスの型。</param>
		/// <param name="instance">サービス インスタンス。</param>
		/// <returns>登録したサービス。</returns>
		/// <exception cref="ArgumentNullException">引数が null である場合。</exception>
		/// <exception cref="ArgumentException">
		/// <paramref name="instance" /> の型が、 <paramref name="serviceType"/> で指定した型と
		/// 互換性がない場合。または <paramref name="serviceType"/> で指定した型が値型である場合。
		/// </exception>
		public object AddService(Type serviceType, object instance)
		{
			if (serviceType == null)
			{
				throw new ArgumentNullException(nameof(serviceType));
			}
			if (instance == null)
			{
				throw new ArgumentNullException(nameof(instance));
			}
			if (serviceType.IsValueType)
			{
				throw
					new ArgumentException(
						message: Resources.ServiceShouldNotValueType,
						paramName: nameof(serviceType));
			}
			if (!serviceType.IsInstanceOfType(instance))
			{
				throw
					new ArgumentException(
						message: Resources.ServiceTypeIsImcompatible, paramName: nameof(instance));
			}
			Container.Add(serviceType, instance);
			return instance;
		}

		/// <summary>
		/// サービスを追加します。
		/// </summary>
		/// <typeparam name="T">サービスの型。</typeparam>
		/// <param name="instance">サービス インスタンス。</param>
		/// <returns>登録したサービス。</returns>
		/// <exception cref="ArgumentNullException">引数が null である場合。</exception>
		public T AddService<T>(T instance) where T : class
		{
			return (T)AddService(serviceType: typeof(T), instance: instance);
		}

		/// <summary>
		/// サービスを削除します。
		/// </summary>
		/// <param name="serviceType">サービスの型。</param>
		/// <returns>サービスを削除できた場合、true。</returns>
		public bool RemoveService(Type serviceType)
		{
			Disposable.Dispose(GetService(serviceType: serviceType));
			return Container.Remove(key: serviceType);
		}

		/// <summary>
		/// サービスを削除します。
		/// </summary>
		/// <typeparam name="T">サービスの型。</typeparam>
		/// <returns>サービスを削除できた場合、true。</returns>
		[SuppressMessage("Microsoft.Design", "CA1004:GenericMethodsShouldProvideTypeParameter")]
		public bool RemoveService<T>() where T : class
		{
			return RemoveService(typeof(T));
		}

		/// <summary>
		/// サービスを取得します。
		/// </summary>
		/// <param name="serviceType">サービスの型。</param>
		/// <returns>サービス インスタンス。存在しない場合、null。</returns>
		public object GetService(Type serviceType)
		{
			return Container.ContainsKey(key: serviceType) ? Container[serviceType] : null;
		}

		/// <summary>
		/// サービスを取得します。
		/// </summary>
		/// <typeparam name="T">サービスの型。</typeparam>
		/// <returns>サービス インスタンス。存在しない場合、null。</returns>
		public T GetService<T>() where T : class
		{
			return (T)GetService(typeof(T));
		}

		/// <summary>
		/// リソースを解放します。
		/// </summary>
		public void Dispose()
		{
			Clear();
		}

		/// <summary>
		/// サービスをすべて削除します。
		/// </summary>
		public void Clear()
		{
			Container.ForEach(p => Disposable.Dispose(instance: p.Value));
			Container.Clear();
		}
	}
}
