using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum EquipmentType
{
    SkinTone = 0,
    Hairstyle = 1,
    Eye = 2,
    Nose = 3,
    Mouth = 4,
    Cheeks = 5,
    HairColor = 6
}

public class EquipmentManager : Singleton<EquipmentManager>
{
    public List<Texture> skins;
    public List<Image> hairColorImages;
    public List<GameObject> hairs, noses, mouths;
    public Material mainMat;
    public Material hairMat;
    public Material eyeMat;
    public Animator playerAnimator;

    int skinIndex, hairIndex, hairColorIndex, eyeIndex, noseIndex, mouthIndex, cheeksIndex;
    List<Color> hairColors;
    private void Start()
    {
        AssignSkin(0);
        AssignHair(0);

        hairColors = new List<Color>();
        foreach (var img in hairColorImages)
            hairColors.Add(img.color);
        AssignHairColor(0);

        AssignEye(0);
        AssignNose(0);
        AssignMouth(0);
        AssignCheek(0);
    }

    public void AssignSkin(int id)
    {
        skinIndex = id;
        mainMat.SetTexture("_BaseMap", skins[skinIndex]);
    }
    public void AssignHair(int id)
    {
        hairIndex = id;
        foreach (var hair in hairs)
            hair.SetActive(false);
        hairs[hairIndex].SetActive(true);
    }
    public void AssignHairColor(int id)
    {
        hairColorIndex = id;
        hairMat.SetColor("_BaseColor", hairColors[hairColorIndex]);
    }
    public void AssignEye(int id)
    {
        eyeIndex = id;
        if (id == 0)
            eyeMat.SetTextureOffset("_BaseMap", new Vector2(1, 0));
        else if (id == 1)
            eyeMat.SetTextureOffset("_BaseMap", new Vector2(1.5f, 0));

    }
    public void AssignNose(int id)
    {
        noseIndex = id;
        foreach (var nose in noses)
            nose.SetActive(false);
        noses[noseIndex].SetActive(true);
    }
    public void AssignMouth(int id)
    {
        mouthIndex = id;
        foreach (var mouth in mouths)
            mouth.SetActive(false);
        mouths[mouthIndex].SetActive(true);
    }
    public void AssignCheek(int id)
    {
        cheeksIndex = id;
    }
    public int GetCurrentEquipment(EquipmentType type)
    {
        switch (type)
        {
            case EquipmentType.SkinTone:
                return skinIndex;
            case EquipmentType.Hairstyle:
                return hairIndex;
            case EquipmentType.Eye:
                return eyeIndex;
            case EquipmentType.Cheeks:
                return cheeksIndex;
            case EquipmentType.Mouth:
                return mouthIndex;
            case EquipmentType.Nose:
                return noseIndex;
            case EquipmentType.HairColor:
                return hairColorIndex;
            default:
                return skinIndex;
        }
    }

    public void AssignEquipment(EquipmentType type, int id)
    {
        if (type == EquipmentType.Hairstyle || type == EquipmentType.HairColor)
            playerAnimator.SetTrigger("LookAt");

        switch (type)
        {
            case EquipmentType.SkinTone:
                AssignSkin(id);
                break;
            case EquipmentType.Hairstyle:
                AssignHair(id);
                break;
            case EquipmentType.Eye:
                AssignEye(id);
                break;
            case EquipmentType.Cheeks:
                AssignCheek(id);
                break;
            case EquipmentType.Mouth:
                AssignMouth(id);
                break;
            case EquipmentType.Nose:
                AssignNose(id);
                break;
            case EquipmentType.HairColor:
                AssignHairColor(id);
                break;
        }
    }
}
