INSERT INTO `Users`
(
   `Username`
  ,`Password`
  ,`Email`
  ,`Firstname`
  ,`Lastname`
)
  SELECT 
    * 
  FROM 
  ( 
    SELECT 
       'roberts'
      ,'password'
      ,'robert@google.com'
      ,'robert'
      ,'hsu'
  ) as temp
WHERE NOT EXISTS (
  SELECT `Username` from `Users` WHERE `Username` = 'robert'
)
