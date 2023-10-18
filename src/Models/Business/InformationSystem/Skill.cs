namespace Cims.WorkflowLib.Models.Business.InformationSystem
{
    /// <summary>
    /// Skill of an employee or a candidate.
    /// </summary>
    public class Skill
    {
        /// <summary>
        /// ID of the skill.
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// UID of the skill.
        /// </summary>
        public string Uid { get; set; }

        /// <summary>
        /// Name of the skill.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Description of the skill.
        /// </summary>
        public string Description { get; set; }
    }
}