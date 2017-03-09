IF NOT EXISTS (SELECT 1 FROM `Users` WHERE `Username` = 'robert')
BEGIN
  INSERT INTO `Users`
  (
     `Username`
    ,`Password`
    ,`Email`
    ,`Firstname`
    ,`Lastname`
  )
  VALUES
  (
     'robert'
    ,'password'
    ,'robert@google.com'
    ,'robert'
    ,'hsu'
  )
END
