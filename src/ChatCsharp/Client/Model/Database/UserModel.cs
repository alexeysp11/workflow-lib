using System;
using System.ComponentModel;

namespace Chat.Client.Database
{
    /// <summary>
    /// Model of a user that is stored in a database  
    /// </summary>
    public class UserModel : System.IDisposable 
    {
        #region Properties
        /// <summary>
        /// Name of a user
        /// </summary>
        /// <value>Public access for reading, private access for changing</value>
        public string Name { get; private set; }
        /// <summary>
        /// Email of a user
        /// </summary>
        /// <value>Public access for reading, private access for changing</value>
        public string Email { get; private set; }
        /// <summary>
        /// Password of a user
        /// </summary>
        /// <value>Public access for reading, private access for changing</value>
        public string Password { get; private set; }
        #endregion  // Properties

        #region Constructor 
        /// <summary>
        /// Constructor of UserModel
        /// </summary>
        /// <param name="name">Name of a user</param>
        /// <param name="email">Email of a user</param>
        /// <param name="password">Password of a user</param>
        public UserModel(string name, string email, string password)
        {
            this.Name = name; 
            this.Email = email; 
            this.Password = password; 
        }
        #endregion  // Constructor

        #region Destructor
        /// <summary>
        /// 
        /// </summary>
        ~UserModel()
        {
            Dispose(false);
        }
        #endregion  // Destructor 

        #region Properties for IDisposable 
        /// <summary>
        /// Pointer to an external unmanaged resource.
        /// </summary>
        private IntPtr handle;
        /// <summary>
        /// Other managed resource this class uses.
        /// </summary>
        private Component component = new Component();
        /// <summary>
        /// Track whether Dispose has been called.
        /// </summary>
        private bool disposed = false;
        /// <summary>
        /// Interop is used to call the method necessary to clean up the unmanaged resource.
        /// </summary>
        [System.Runtime.InteropServices.DllImport("Kernel32")]
        private extern static Boolean CloseHandle(IntPtr handle);
        #endregion  // Properties for IDisposable 

        #region Dispose methods
        /// <summary>
        /// 
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// 
        /// </summary>
        protected virtual void Dispose(bool disposing)
        {
            if(!this.disposed)
            {
                if(disposing)
                    component.Dispose();
                CloseHandle(handle);
                handle = IntPtr.Zero;
                disposed = true;
            }
        }
        #endregion  // Dispose methods
    }
}