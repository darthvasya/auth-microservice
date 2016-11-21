using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthServer.DAL
{
    public class Disposable : IDisposable
    {
        // Используется для выяснения того, вызывался ли уже метод Dispose()
        private bool isDisposed;

        public void Dispose()
        {
            // Вызов вспомогательного метода.
            // Значение true указывает на то, что очистка
            // была инициирована пользователем объекта.
            Cleanup(true);
            // Подавление финализации.
            GC.SuppressFinalize(this);
        }

        private void Cleanup(bool disposing)
        {
            // Проверка, выполнялась ли очистка,
            if (!isDisposed)
            {
                // Если disposing равно true, должно осуществляться
                // освобождение всех управляемых ресурсов,
                if (disposing)
                {
                    DisposeCore();
                }
                // Очистка неуправляемых ресурсов.
            }
            isDisposed = true;
        }


        ~Disposable()
        {
            // Вызов вспомогательного метода.
            // Значение false указывает на то, что
            // очистка была инициирована сборщиком мусора.
            Cleanup(false);
        }

        protected virtual void DisposeCore()
        {

        }
    }

}
