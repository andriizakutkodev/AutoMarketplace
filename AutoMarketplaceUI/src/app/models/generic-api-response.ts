/**
 * Interface representing the structure of an API response.
 */
export interface GenericApiResponse<T> {
  /**
   * Indicates whether the API request was successful.
   */
  isSuccess: boolean;

  /**
   * The HTTP status code returned by the API.
   */
  statusCode: number;

  /**
   * A message providing additional information about the response.
   * Typically used for success or error descriptions.
   */
  message: string;

  /**
   * The actual data returned from the API.
   * Can be of any type, depending on the nature of the API response.
   */
  data: T;
}
