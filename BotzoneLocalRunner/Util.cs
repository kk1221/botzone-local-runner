﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace BotzoneLocalRunner
{
    internal interface IValidationBubbling
    {
        bool IsValid { get; set; }
        string ValidationString { get; set; }
        event EventHandler ValidationChanged;
    }

	#region MVVM数据绑定辅助
	[ValueConversion(typeof(double[]), typeof(string))]
	public class ArrayToStringConverter : MarkupExtension, IValueConverter
	{

		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
			=> String.Join(", ", (double[])value);

		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
			=> null;
		public override object ProvideValue(IServiceProvider serviceProvider)
			=> this;
	}

	[ValueConversion(typeof(bool), typeof(Visibility))]
	public class InverseBooleanToVisibilityConverter : MarkupExtension, IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter,
			CultureInfo culture)
			=> (bool)value ? Visibility.Collapsed : Visibility.Visible;

		public object ConvertBack(object value, Type targetType, object parameter,
			CultureInfo culture)
			=> null;
		public override object ProvideValue(IServiceProvider serviceProvider)
			=> this;
	}

	public class RangeObservableCollection<T> : ObservableCollection<T>
	{
		public RangeObservableCollection() { }
		public RangeObservableCollection(List<T> list) : base(list) { }
		public RangeObservableCollection(IEnumerable<T> collection) : base(collection) { }

		private bool _suppressNotification = false;

		protected override void OnCollectionChanged(NotifyCollectionChangedEventArgs e)
		{
			if (!_suppressNotification)
				base.OnCollectionChanged(e);
		}

		public void AddRange(IEnumerable<T> list)
		{
			if (list == null)
				throw new ArgumentNullException(nameof(list));

			_suppressNotification = true;

			foreach (T item in list)
			{
				Add(item);
			}
			_suppressNotification = false;
			OnCollectionChanged(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Reset));
		}
	}

	public class ValueDescription
	{
		public Enum Value { get; set; }
		public string Description { get; set; }
		public static implicit operator Enum(ValueDescription me) => me.Value;

		public override bool Equals(object obj) => Value.Equals((obj as ValueDescription)?.Value);

		public override int GetHashCode() => Value?.GetHashCode() ?? 0;
	}

	[ValueConversion(typeof(ValueDescription), typeof(Enum))]
	public class ValueDescriptionToEnumConverter : MarkupExtension, IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
			=> new ValueDescription { Value = (Enum)value, Description = ((Enum) value).Description() };

		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
			=> (value as ValueDescription)?.Value;

		public override object ProvideValue(IServiceProvider serviceProvider)
			=> this;
	}

	[ValueConversion(typeof(Enum), typeof(IEnumerable<ValueDescription>))]
	public class EnumToCollectionConverter : MarkupExtension, IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
			=> EnumHelper.GetAllValuesAndDescriptions(value.GetType());

		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
			=> null;

		public override object ProvideValue(IServiceProvider serviceProvider)
			=> this;
	}

	public static class EnumHelper
	{
		public static string Description(this Enum eValue)
		{
			var nAttributes = eValue.GetType().GetField(eValue.ToString()).GetCustomAttributes(typeof(DescriptionAttribute), false);
			if (nAttributes.Any())
				return (nAttributes.First() as DescriptionAttribute).Description;

			return eValue.ToString();
		}

		public static IEnumerable<ValueDescription> GetAllValuesAndDescriptions(Type t)
			=> from Enum e in Enum.GetValues(t)
			   select new ValueDescription { Value = e, Description = e.Description() };
	}

	public static class BitmapHelper
	{
		[System.Runtime.InteropServices.DllImport("gdi32.dll")]
		public static extern bool DeleteObject(IntPtr hObject);
	}

	[ValueConversion(typeof(Bitmap), typeof(BitmapSource))]
	public class BitmapRGBAToWPFConverter : MarkupExtension, IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			var hBitmap = (value as Bitmap).GetHbitmap();
			
			try
			{
				return System.Windows.Interop.Imaging.CreateBitmapSourceFromHBitmap(
					hBitmap, IntPtr.Zero, Int32Rect.Empty,
					BitmapSizeOptions.FromEmptyOptions());
			}
			finally
			{
				BitmapHelper.DeleteObject(hBitmap);
			}
		}

		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
			=> null;

		public override object ProvideValue(IServiceProvider serviceProvider)
			=> this;
	}

	//public class ScrollToEndBehavior : Behavior<ScrollViewer>
	//{
	//	public Action ScrollToEndAction
	//	{
	//		get { return (Action)GetValue(ScrollToEndActionProperty); }
	//		set { SetValue(ScrollToEndActionProperty, value); }
	//	}
		
	//	public static readonly DependencyProperty ScrollToEndActionProperty =
	//		DependencyProperty.Register("ScrollToEndAction", typeof(Action), typeof(ScrollToEndBehavior), new PropertyMetadata(null));

	//	protected override void OnAttached()
	//	{
	//		SetCurrentValue(ScrollToEndActionProperty, (Action)AssociatedObject.ScrollToEnd);
	//		base.OnAttached();
	//	}
	//}
	#endregion

	internal static class Util
    {
		internal static ILogger Logger { get; set; }
    }
}
