using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public interface ISocialUser 
{
	string UserID 					{ get; } //read only
	string UserName 				{ get; } //read only
	string UserLastName 			{ get; } //read only
	string UserGender 				{ get; } //read only
	string UserLocation 			{ get; } //read only
	string UserBirthDay 			{ get; } //read only
	string SmallUserPhotoURL 		{ get; } //read only
	string MiddleUserPhotoURL 		{ get; } //read only
	string BigUserPhotoURL 			{ get; } //read only
	string InternalUserID 			{ get; } //read only
	List<ISocialFriend> Friends 	{ get; } //read only
	List<ISocialFriend> AppFriends 	{ get; } //read only

	void MakePurchase(string name, string description, string code, int price);
 	void PublishToStream(string Title, string Message, string ImgURL);
}
