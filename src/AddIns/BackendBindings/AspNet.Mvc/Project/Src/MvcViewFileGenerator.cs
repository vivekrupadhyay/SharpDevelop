﻿// Copyright (c) AlphaSierraPapa for the SharpDevelop Team (for details please see \doc\copyright.txt)
// This code is distributed under the GNU LGPL (for details please see \doc\license.txt)

using System;
using ICSharpCode.SharpDevelop.Project;

namespace ICSharpCode.AspNet.Mvc
{
	public class MvcViewFileGenerator : MvcFileGenerator, IMvcViewFileGenerator
	{
		MvcTextTemplateRepository textTemplateRepository;
		
		public MvcViewFileGenerator()
			: this(
				new MvcTextTemplateHostFactory(),
				new MvcTextTemplateRepository())
		{
		}
		
		public MvcViewFileGenerator(
			IMvcTextTemplateHostFactory hostFactory,
			MvcTextTemplateRepository textTemplateRepository)
			: base(hostFactory)
		{
			this.textTemplateRepository = textTemplateRepository;
			
			ModelClassName = String.Empty;
			MasterPageFile = String.Empty;
			PrimaryContentPlaceHolderId = String.Empty;
			Template = new MvcViewTextTemplate();
		}
		
		public string ModelClassName { get; set; }
		public bool IsContentPage { get; set; }
		public string MasterPageFile { get; set; }
		public string PrimaryContentPlaceHolderId { get; set; }
		public MvcViewTextTemplate Template { get; set; }
		
		public void GenerateFile(MvcViewFileName fileName)
		{
			base.GenerateFile(fileName);
		}
		
		protected override void ConfigureHost(IMvcTextTemplateHost host, MvcFileName fileName)
		{
			host.IsContentPage = IsContentPage;
			host.MasterPageFile = MasterPageFile;
			host.PrimaryContentPlaceHolderID = PrimaryContentPlaceHolderId;
			host.ViewDataTypeName = ModelClassName;
			
			var viewFileName = fileName as MvcViewFileName;
			host.IsPartialView = viewFileName.IsPartialView;
			host.ViewName = viewFileName.ViewName;
		}
		
		protected override string GetTextTemplateFileName()
		{
			return Template.FileName;
		}
	}
}
