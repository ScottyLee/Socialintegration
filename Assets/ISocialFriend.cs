using UnityEngine;
using System.Collections;

public interface ISocialFriend
{
	string UserID  				{ get; } //read only
	string UserName 			{ get; } //read only
	string UserLastName 		{ get; } //read only
	string SmallUserPhotoURL 	{ get; } //read only
	string MiddleUserPhotoURL 	{ get; } //read only
	string BigUserPhotoURL 		{ get; } //read only
}
