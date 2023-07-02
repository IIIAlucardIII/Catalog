namespace Catalog.Models
{
    public class FolderModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? ParentId { get; set; }
        public string Path { get; set; }
        public IEnumerable<FolderModel> Children { get; set; }

        public FolderModel()
        {
            Children = new List<FolderModel>();
        }

        public FolderModel GetChild(int id)
        {
            FolderModel item = null;
            foreach (var child in Children)
            {
                if (child.Id == id)
                {
                    item = child;
                }
            }
            return item;
        }
        public FolderModel GetChildRecoursively(int id)
        {
            var child = GetChild(id);

            if (child == null)
            {
                foreach (var item in Children)
                {
                    var c = item.GetChildRecoursively(id);
                    if (c != null)
                    {
                        child = c;
                        break;
                    }
                }
            }

            return child;
        }
        static FolderModel()
        {
            Structure = new FolderModel()
            {
                Id = 1,
                Name = "Creating Digital Images",
                Path = "Creating Digital Images",
                ParentId = null,
                Children = new[]
                {
                    new FolderModel()
                    {
                        Id = 2,
                        Name = "Resources",
                        Path = "Creating Digital Images/Resources",
                        ParentId = 1,
                        Children = new[]
                        {
                            new FolderModel
                            {
                                Id = 5,
                                Name = "Primary Sources",
                                Path = "Creating Digital Images/Resources/Primary Sources",
                                ParentId = 2,
                            },
                            new FolderModel
                            {
                                Id = 6,
                                Name = "Secondary Sources",
                                Path = "Creating Digital Images/Resources/Secondary Sources",
                                ParentId = 2,
                            }
                        }
                    },
                    new FolderModel()
                    {
                        Id = 3,
                        ParentId = 1,
                        Name ="Evidence",
                        Path ="Creating Digital Images/Evidence"
                    },
                    new FolderModel()
                    {
                        Id = 4,
                        ParentId = 1,
                        Name ="Graphic Products",
                        Path ="Creating Digital Images/Graphic Products",
                        Children = new[]
                        {
                            new FolderModel
                            {
                                Id = 7,
                                ParentId = 4,
                                Name = "Process",
                                Path = "Creating Digital Images/Graphic Products/Process"
                            },
                            new FolderModel
                            {
                                Id = 8,
                                ParentId = 4,
                                Name = "Final Product",
                                Path = "Creating Digital Images/Graphic Products/Final Product"
                            },
                        }
                    },
                }
            };
            CurrentFolder = Structure;
        }
        public static FolderModel Structure;
        public static FolderModel CurrentFolder;
    }
}
