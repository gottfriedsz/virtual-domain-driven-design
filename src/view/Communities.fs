namespace VDDD

module Communities =

  open Fable.Helpers.React
  open Fable.Helpers.React.Props
  open VDDD.Types
  
    type Profile = {
    Image : string
    Location: string
    Date: string
    Website : string }
  
  let community (c:Community) =
   div [ Class "group card-hoverable bg-white w-48 rounded-lg shadow-md m-2 flex flex-col items-center justify-start" ]
           [ div [ Class "flex flex-col items-center justify-start h-64" ]
              [
               div [ Class "m-2 font-semibold text-gray-800 text-sm text-center" ]
                [ str c.name ]
  
               div [ Class "text-gray-700 text-xs italic text-center" ]
                [ 
                  ( match c.city with
                    | Some place -> str (place + ", ")
                    | None -> str "" )
                  str c.country 
                ] 
               
               a [ Class ""
                   Href c.url
                   Target "_blank"]
                [ img [ Class "h-48 w-64 object-contain"
                        Src c.img ] ]
              ]
             ]
  
  let render model dispatch =
     div [ Class "content bg-gray-200" ; Id "communities"]
        [ div [ Class "w-full flex flex-col items-center justify-start" ]
            [ h2 [ Class "my-6 w-4/5 lg:w-2/3 xl:w-1/2" ]
                [ str "Communities"]
              div [ Class "w-11/12 md:w-5/6" ]
                  [ div [ Class "flex justify-center flex-wrap" ]
                      ( model.communities
                        |> List.map community )
                  ]
              ]
        ]