using System;
using System.Collections.Generic;

using System.Collections.Tests;
using System.Runtime.InteropServices;

namespace DrNet.Tests.UnsafeSpan
{
    public abstract class IList_Tests<T> : IList_Generic_Tests<T>, IDisposable
    {
        #region IEnumerable<T> Helper Methods

        protected override bool Enumerator_Current_UndefinedOperation_Throws => true;
        protected override bool Enumerator_ModifiedDuringEnumeration_ThrowsInvalidOperationException => false;

        #endregion

        #region ICollection<T> Helper Methods

        protected override bool AddRemoveClear_ThrowsNotSupported => true;

        protected override Type ICollection_Generic_CopyTo_IndexLargerThanArrayCount_ThrowType => 
            typeof(ArgumentOutOfRangeException);

        #endregion

        #region IList<T> Helper Methods

        protected sealed override IList<T> GenericIListFactory() => throw new NotSupportedException();

        /// <summary>
        /// Creates an instance of an IList{T} that can be used for testing.
        /// </summary>
        /// <param name="count">The number of unique items that the returned IList{T} contains.</param>
        /// <returns>An instance of an IList{T} that can be used for testing.</returns>
        protected override IList<T> GenericIListFactory(int count) => throw new NotImplementedException();

        #endregion

        #region IList_Tests<T> Helper Methods

        protected readonly List<GCHandle> PinnedHandles = new List<GCHandle>();

        /// <summary>
        /// Creates an instance of an Span{T} that can be used for testing.
        /// </summary>
        /// <param name="count">The number of unique items that the returned Span{T} contains.</param>
        /// <returns>An instance of an Span{T} that can be used for testing.</returns>
        protected virtual Span<T> GenericPinnedFactory(int count)
        {
            List<T> collection = new List<T>(count);
            AddToCollection(collection, count);

            T[] array = collection.ToArray();
            GCHandle handle = GCHandle.Alloc(array, GCHandleType.Pinned);
            try
            {
                PinnedHandles.Add(handle);
            }
            catch
            {
                handle.Free();
                throw;
            }

            return array;
        }

        #endregion

        #region IDisposable Support

        private bool disposedValue = false; // Для определения избыточных вызовов

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                disposedValue = true;

                if (disposing)
                {
                    // TODO: освободить управляемое состояние (управляемые объекты).
                }

                // TODO: освободить неуправляемые ресурсы (неуправляемые объекты) и переопределить ниже метод завершения.
                // TODO: задать большим полям значение NULL.

                foreach (GCHandle handle in PinnedHandles)
                    handle.Free();

                PinnedHandles.Clear();
            }
        }

        // TODO: переопределить метод завершения, только если Dispose(bool disposing) выше включает код для освобождения неуправляемых ресурсов.
        ~IList_Tests()
        {
            // Не изменяйте этот код. Разместите код очистки выше, в методе Dispose(bool disposing).
            Dispose(false);
        }

        // Этот код добавлен для правильной реализации шаблона высвобождаемого класса.
        public void Dispose()
        {
            // Не изменяйте этот код. Разместите код очистки выше, в методе Dispose(bool disposing).
            Dispose(true);
            // TODO: раскомментировать следующую строку, если метод завершения переопределен выше.
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}
