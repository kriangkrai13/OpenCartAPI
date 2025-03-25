﻿//////////////////////////////////////////////////////////////
// <auto-generated>This code was generated by LLBLGen Pro v5.11.</auto-generated>
//////////////////////////////////////////////////////////////
// Code is generated on: 
// Code is generated using templates: SD.TemplateBindings.SharedTemplates
// Templates vendor: Solutions Design.
//////////////////////////////////////////////////////////////
using System;
using OpenCart.FactoryClasses;
using OpenCart.RelationClasses;
using SD.LLBLGen.Pro.ORMSupportClasses;

namespace OpenCart.HelperClasses
{
	/// <summary>Singleton implementation of the ModelInfoProvider. This class is the singleton wrapper through which the actual instance is retrieved.</summary>
	public static class ModelInfoProviderSingleton
	{
		private static readonly IModelInfoProvider _providerInstance = new ModelInfoProviderCore();

		/// <summary>Dummy static constructor to make sure threadsafe initialization is performed.</summary>
		static ModelInfoProviderSingleton()	{ }

		/// <summary>Gets the singleton instance of the ModelInfoProviderCore</summary>
		/// <returns>Instance of the FieldInfoProvider.</returns>
		public static IModelInfoProvider GetInstance()
		{
			return _providerInstance;
		}
	}

	/// <summary>Actual implementation of the ModelInfoProvider.</summary>
	internal class ModelInfoProviderCore : ModelInfoProviderBase
	{
		/// <summary>Initializes a new instance of the <see cref="ModelInfoProviderCore"/> class.</summary>
		internal ModelInfoProviderCore()
		{
			Init();
		}

		/// <summary>Method which initializes the internal datastores.</summary>
		private void Init()
		{
			this.InitClass();
			InitUserEntityInfo();
			this.BuildInternalStructures();
		}

		/// <summary>Inits UserEntity's info objects</summary>
		private void InitUserEntityInfo()
		{
			this.AddFieldIndexEnumForElementName(typeof(UserFieldIndex), "UserEntity");
			this.AddElementFieldInfo("UserEntity", "UserId", typeof(System.Int32), true, false, true, false,  (int)UserFieldIndex.UserId, 0, 0, 10);
			this.AddElementFieldInfo("UserEntity", "Firstname", typeof(System.String), false, false, false, false,  (int)UserFieldIndex.Firstname, 50, 0, 0);
			this.AddElementFieldInfo("UserEntity", "Lastname", typeof(System.String), false, false, false, false,  (int)UserFieldIndex.Lastname, 50, 0, 0);
			this.AddElementFieldInfo("UserEntity", "Username", typeof(System.String), false, false, false, false,  (int)UserFieldIndex.Username, 50, 0, 0);
			this.AddElementFieldInfo("UserEntity", "Password", typeof(System.String), false, false, false, false,  (int)UserFieldIndex.Password, 2147483647, 0, 0);
			this.AddElementFieldInfo("UserEntity", "IsActive", typeof(System.Boolean), false, false, false, false,  (int)UserFieldIndex.IsActive, 0, 0, 0);
		}
	}
}