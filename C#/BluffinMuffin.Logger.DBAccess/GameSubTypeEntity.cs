//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace BluffinMuffin.Logger.DBAccess
{
    using System;
    using System.Collections.Generic;
    
    internal partial class GameSubTypeEntity
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public GameSubTypeEntity()
        {
            this.TableParamsUsingGameSubType = new HashSet<TableParamEntity>();
        }
    
        public int Id { get; set; }
        public int GameTypeId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    
        internal virtual GameTypeEntity GameType { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        internal virtual ICollection<TableParamEntity> TableParamsUsingGameSubType { get; set; }
    }
}
