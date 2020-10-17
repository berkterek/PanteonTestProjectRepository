using PanteonTestProject.Abstracts.Controllers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PanteonTestProject.Controllers
{
    public class NpcController : EntityController
    {


        protected override void HandleFinishRace()
        {
            Debug.Log(this.gameObject.name + " finish race");
        }
    }
}

