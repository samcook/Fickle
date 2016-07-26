﻿using System.IO;
using Fickle.Expressions;
using Fickle.Generators.CSharp.Binders;
using Platform.VirtualFileSystem;
using Fickle.Model;

namespace Fickle.Generators.CSharp
{
	[ServiceModelCodeGenerator("csharp")]
	public class CSharpServiceModelCodeGenerator
		: ServiceModelCodeGenerator
	{
		public CSharpServiceModelCodeGenerator(IFile file, CodeGenerationOptions options)
			: base(file, options)
		{
		}

		public CSharpServiceModelCodeGenerator(TextWriter writer, CodeGenerationOptions options)
			: base(writer, options)
		{
		}

		public CSharpServiceModelCodeGenerator(IDirectory directory, CodeGenerationOptions options)
			: base(directory, options)
		{
		}

		protected override ServiceModel ProcessPregeneration(ServiceModel serviceModel)
		{
			return serviceModel;
		}

		protected override void GenerateClass(CodeGenerationContext codeGenerationContext, TypeDefinitionExpression expression)
		{
			using (var writer = this.GetTextWriterForFile(expression.Type.Name + ".cs"))
			{
				var classFileExpression = CSharpClassExpressionBinder.Bind(codeGenerationContext, expression);

				var codeGenerator = new CSharpCodeGenerator(writer);

				codeGenerator.Generate(classFileExpression);
			}
		}

		protected override void GenerateGateway(CodeGenerationContext codeGenerationContext, TypeDefinitionExpression expression)
		{
			using (var writer = this.GetTextWriterForFile(expression.Type.Name + ".cs"))
			{
				var classFileExpression = CSharpGatewayExpressionBinder.Bind(codeGenerationContext, expression);

				var codeGenerator = new CSharpCodeGenerator(writer);

				codeGenerator.Generate(classFileExpression);
			}
		}

		protected override void GenerateEnum(CodeGenerationContext codeGenerationContext, TypeDefinitionExpression expression)
		{
			using (var writer = this.GetTextWriterForFile(expression.Type.Name + ".cs"))
			{
				var enumFileExpression = CSharpEnumExpressionBinder.Bind(codeGenerationContext, expression);

				var codeGenerator = new CSharpCodeGenerator(writer);

				codeGenerator.Generate(enumFileExpression);
			}
		}
	}
}
