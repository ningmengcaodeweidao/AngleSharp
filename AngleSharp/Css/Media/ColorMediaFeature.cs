﻿namespace AngleSharp.Css.Media
{
    using AngleSharp.DOM;
    using AngleSharp.DOM.Css;
    using AngleSharp.Extensions;
    using System;

    sealed class ColorMediaFeature : MediaFeature
    {
        #region Fields

        static readonly IValueConverter<Int32> Converter = Converters.IntegerConverter.Constraint(m => m > 0);
        Int32 _color;

        #endregion

        #region ctor

        public ColorMediaFeature(String name)
            : base(name)
        {
        }

        #endregion

        #region Methods

        protected override Boolean TrySetDefault()
        {
            _color = 1;
            return true;
        }

        protected override Boolean TrySetCustom(ICssValue value)
        {
            return Converter.TryConvert(value, m => _color = m);
        }

        public override Boolean Validate(IWindow window)
        {
            return true;
        }

        #endregion
    }
}