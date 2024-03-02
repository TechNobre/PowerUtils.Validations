#region License
// Copyright (c) .NET Foundation and contributors.
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
// http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
//
// The latest version of this file can be found at https://github.com/FluentValidation/FluentValidation
#endregion


using System;
using System.Collections.Generic;

namespace PowerUtils.Validations.Contracts
{
    [Obsolete("This package has been discontinued because it never evolved, and the code present in this package does not justify its continuation. It is preferable to implement this code directly in the project if necessary.")]
    public class PropertyRule<TSource, TProperty> : IPropertyRule<TSource, TProperty>
    {
        public bool PropertyNull { get; init; }
        public string PropertyName { get; init; }
        public TProperty PropertyValue { get; init; }


        public bool Valid => Notifications.Count == 0;
        public bool Invalid => !Valid;

        public IReadOnlyCollection<ValidationFailure> Notifications => _context.Notifications;


        private IValidationsContract<TSource> _context { get; }


        public PropertyRule(
            IValidationsContract<TSource> context,
            string propertyName
        )
        {
            PropertyNull = true;
            _context = context;
            PropertyName = propertyName;
        }

        public PropertyRule(
            IValidationsContract<TSource> context,
            string propertyName,
            TProperty propertyValue
        )
            : this(context, propertyName)
        {
            _context = context;
            PropertyValue = propertyValue;
            PropertyName = propertyName;

            if(PropertyValue != null)
            {
                PropertyNull = false;
            }
        }


        public void AddNotification(string errorCode) =>
            _context.AddNotification(PropertyName, errorCode);
    }
}
