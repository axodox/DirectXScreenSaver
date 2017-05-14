using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace InfoCore
{
    public abstract class InfoObject : IDisposable
    {
        public Size Size
        {
            get;
            protected set;
        }
        public string Name
        {
            get;
            protected set;
        }
        public long RefreshTime
        {
            get;
            protected set;
        }
        public abstract Bitmap Draw();

        public bool IsDisposed;
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        protected abstract void Dispose(bool Disposing);
        public virtual void ShowOptions()
        {
            throw new NotImplementedException();
        }
    }
}
