#nullable enable

using Microsoft.Windows.Design.Metadata;

[assembly: ProvideMetadata(typeof(Uno.UI.Design.RegisterMetadata))]

namespace Uno.UI.Design
{
	internal class RegisterMetadata : IProvideAttributeTable
	{
		public AttributeTable AttributeTable => new AttributeTableBuilder().CreateTable();
	}
}
