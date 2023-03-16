using GraphQL;
using GraphQL.Client.Abstractions;
using WorkerService1;

namespace GraphQLTest;

public class OwnerConsumer
{
    private readonly IGraphQLClient _client;
    public OwnerConsumer(IGraphQLClient client)
    {
        _client = client;
    }
    
    public async Task<List<Carrier>> GetCarriers(int startingRecord, int length, string id = "")
    {
        GraphQLRequest query = new GraphQLRequest
        {
            Query = @"
                query($carrier: String, $start: Int!, $count: Int!) { 
                    carriers(startingRecord: $start, length: $count, carrier: $carrier){
                        name,
                        account,
                        address1
                    }
            }",
            Variables = new
            {
                start = startingRecord,
                count = length,
                carrier = id
            }
        };
        GraphQLResponse<ResponseOwnerCollectionType> response = await _client.SendQueryAsync<ResponseOwnerCollectionType>(query);
        return response.Data.Carriers;
    }
    
    public async Task<List<Amaster>> GetAccounts(string account)
    {
        
        // mutation CreateReviewForEpisode($ep: Episode!, $review: ReviewInput!) {
        //     createReview(episode: $ep, review: $review) {
        //         stars
        //             commentary
        //     }
        // }
        
        
        GraphQLRequest query = new GraphQLRequest
        {
            Query = @"
                query CreateReviewForEpisode($account: String) { 
                    accounts (account: $account){
                        name,
                        account,
                        apcarrier,
                        address1,
                        address2,
                        city,
                        state
                    }
            }",
            Variables = new
            {
                account = account
            }
        };
        GraphQLResponse<List<Amaster>> response = await _client.SendQueryAsync<List<Amaster>>(query);
        return response.Data;
    }
    
}