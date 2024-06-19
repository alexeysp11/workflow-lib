using System;
using System.ComponentModel;

namespace Chat.Server.Database
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
        /// Use C# destructor syntax for finalization code.
        /// This destructor will run only if the Dispose method
        /// does not get called.
        /// It gives your base class the opportunity to finalize.
        /// Do not provide destructors in types derived from this class.
        /// </summary>
        ~UserModel()
        {
            // Do not re-create Dispose clean-up code here.
            // Calling Dispose(false) is optimal in terms of
            // readability and maintainability.
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

        // Use interop to call the method necessary to clean up the unmanaged resource.
        [System.Runtime.InteropServices.DllImport("Kernel32")]
        private extern static Boolean CloseHandle(IntPtr handle);
        #endregion  // Properties for IDisposable 

        #region Dispose methods
        /// <summary>
        /// Implement IDisposable.
        /// Do not make this method virtual.
        /// A derived class should not be able to override this method.
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            
            // This object will be cleaned up by the Dispose method.
            // Therefore, you should call GC.SupressFinalize to
            // take this object off the finalization queue
            // and prevent finalization code for this object
            // from executing a second time.
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Dispose(bool disposing) executes in two distinct scenarios.
        /// If disposing equals true, the method has been called directly
        /// or indirectly by a user's code. Managed and unmanaged resources
        /// can be disposed.
        /// If disposing equals false, the method has been called by the
        /// runtime from inside the finalizer and you should not reference
        /// other objects. Only unmanaged resources can be disposed.
        /// </summary>
        protected virtual void Dispose(bool disposing)
        {
            // Check to see if Dispose has already been called.
            if(!this.disposed)
            {
                // If disposing equals true, dispose all managed
                // and unmanaged resources.
                if(disposing)
                {
                    // Dispose managed resources.
                    component.Dispose();
                }

                // Call the appropriate methods to clean up
                // unmanaged resources here.
                // If disposing is false,
                // only the following code is executed.
                CloseHandle(handle);
                handle = IntPtr.Zero;

                // Note disposing has been done.
                disposed = true;
            }
        }
        #endregion  // Dispose methods
    }
}