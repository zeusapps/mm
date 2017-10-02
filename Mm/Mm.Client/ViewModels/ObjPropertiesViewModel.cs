using System;
using GalaSoft.MvvmLight;
using Mm.Core.DTOs;

namespace Mm.Client.ViewModels
{
    public class ObjPropertiesViewModel : ViewModelBase
    {
        public Guid PropertyId => Value.PropertyId;
        public byte[] Marked => Value.Marked;

        public string PropertyName
        {
            get => Value.PropertyName;
            set
            {
                Value.PropertyName = value;
                RaisePropertyChanged(() => PropertyName);
            }
        }

        public ObjPropertiesViewModel(ObjPropertiesDto dto)
        {
            Value = dto;
        }

        public ObjPropertiesDto Value { get; }
    }
}
