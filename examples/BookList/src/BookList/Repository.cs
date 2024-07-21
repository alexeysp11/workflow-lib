using WorkflowLib.Examples.BookList.Services;

namespace WorkflowLib.Examples.BookList
{
    /// <summary>
    /// Static class for storing and accessing classes that implement 
    /// Repository pattern
    /// </summary>
    public static class Repository
    {
        #region Fields
        /// <summary>
        /// Private static field for storing an instance of MockUserRepository.
        /// </summary>
        private static IUserRepository userRepository = null;
        
        /// <summary>
        /// Private static field for getting if the user is athenticated.
        /// </summary>
        private static bool isAuthenticated = false;
        #endregion  // Fields

        #region Properties
        /// <summary>
        /// Property for getting an instance of UserRepository class.
        /// </summary>
        /// <value>Public readonly property</value>
        public static IUserRepository UserRepositoryInstance
        {
            get 
            {
                if (userRepository == null)
                {
                    userRepository = new UserRepository();
                }
                return userRepository;
            }
        }
        
        /// <summary>
        /// Gets and sets if an user is authenticated 
        /// </summary>
        /// <value>Public property for getting and setting isAuthenticated</value>
        public static bool IsAuthenticated
        {
            get { return isAuthenticated; }
            set
            {
                isAuthenticated = value;
            }
        }
        #endregion  // Properties
    }
}