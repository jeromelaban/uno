﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Windows.UI.Xaml.Data;

namespace Uno.UI.Extensions
{
	public static class CollectionViewExtensions
	{
		[System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
		public static IEnumerable<IEnumerable> GetCollectionGroups(this ICollectionView collectionView)
		{
			return collectionView.CollectionGroups?.Cast<ICollectionViewGroup>().Select(g => g.Group as IEnumerable);
		}

		public static IndexPath GetIndexPathForItem(this ICollectionView collectionView, object item)
		{
			if (collectionView.CollectionGroups == null)
			{
				return IndexPath.FromRowSection(collectionView.IndexOf(item), 0);
			}

			for (int i = 0; i < collectionView.CollectionGroups.Count; i++)
			{
				var row = (collectionView.CollectionGroups[i] as ICollectionViewGroup).GroupItems.IndexOf(item);

				if (row > -1)
				{
					return IndexPath.FromRowSection(row, i);
				}
			}

			// Not found
			return IndexPath.FromRowSection(-1, 0);
		}

		public static object GetItemForIndexPath(this ICollectionView collectionView, IndexPath indexPath)
		{
			if (collectionView.CollectionGroups == null)
			{
				if (indexPath.Section > 0)
				{
					return null;
				}

				return collectionView[indexPath.Row];
			}

			return (collectionView.CollectionGroups[indexPath.Section] as ICollectionViewGroup).GroupItems[indexPath.Row];
		}
	}
}
