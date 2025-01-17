﻿using Prism.Commands;
using Prism.Mvvm;
using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Linq;
using Akavache;

namespace Sandbox.ViewModels
{
	public class ReactPageViewModel : ReactiveObject
    {
        private string myProperty;
        public string MyProperty
        {
            get
            {
                return myProperty;
            }
            set
            {
                this.RaiseAndSetIfChanged(ref myProperty, value);
            }
        }

        public ReactiveCommand TapCommand { get; private set; }
        public ReactPageViewModel()
        {
            Init();
        }

        private void Init()
        {
            this.WhenAnyValue(x => x.MyProperty)
                .Subscribe(c => MyProperty = c?.ToUpper());

            BlobCache.InMemory.InsertObject("test", MyProperty);

            TapCommand = ReactiveCommand.CreateFromTask(async () => {
                MyProperty = "Ner";
            });
        }
	}
}
