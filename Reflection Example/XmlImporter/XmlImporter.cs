﻿using Domain;
using ImporterInterface;

namespace XmlImporter;

public class XmlImporter : IImporter
{
  public string GetName()
  {
    return "XML Importer";
  }

  public List<Pet> ImportPets()
  {
    // Deberia leer de un archivo XML.....
    return new List<Pet>() { new Pet() { Id = 1000, Name = "No se", Age = 3 } };
  }
}
