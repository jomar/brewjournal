﻿using System;
using Xamarin.Forms;

namespace BrewLog
{
	public class BrewPage : ContentPage
	{
		protected int _Id;
		protected Brew _Brew;
		protected StackLayout _Layout;

		public BrewPage (int id)
		{
			_Id = id;

			_Layout = new StackLayout()
            {
				HorizontalOptions = LayoutOptions.FillAndExpand,
                Orientation = StackOrientation.Vertical,
               	Padding = 5.0f,
			};

			Content = _Layout;
		}

		protected View AddWidget(View widget)
		{
			Layout.Children.Add(widget);
			return widget;
		}

		protected StackLayout Layout
		{
			get { return _Layout; }
		}

		protected bool SaveBrew(Brew brew)
		{
			if (VerifyValues(brew))
			{
				using (var db = global::Brew.SQLite.Connection.Invoke())
				{
					db.Insert(brew);
					db.Commit();
					db.Close();
				}
				return true;
			}
			else
				return false;
		}

		protected bool VerifyValues(Brew brew)
		{
			if (brew.Name == null || brew.Name.Length == 0)
			{
				return false;
			}

			return true;
		}

		public Brew Brew
		{
			get
			{
				if (_Brew == null)
				{
					using(var db = global::Brew.SQLite.Connection.Invoke())
					{
						var brew = db.Table<Brew>().Where(v => v.Id == _Id);
						if (brew != null && brew.Count() > 0)
							_Brew = brew.First();
						else
							_Brew = new Brew() { Id = _Id };
					}
				}
				return _Brew;
			}
		}
	}
}
